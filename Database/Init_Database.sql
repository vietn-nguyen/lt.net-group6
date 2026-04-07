USE master
GO

-- Xóa DB cũ nếu đã tồn tại để tránh lỗi
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyNhanKhauTinh')
BEGIN
    ALTER DATABASE QuanLyNhanKhauTinh SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE QuanLyNhanKhauTinh
END
GO

CREATE DATABASE QuanLyNhanKhauTinh
GO
USE QuanLyNhanKhauTinh
GO

-- 1. CÁC BẢNG DANH MỤC GỐC
create table TinhTP (
    id int identity primary key,
    maTinh varchar(10) unique not null,
    tenTinh nvarchar(100) not null
)

create table XaPhuong (
    id int identity primary key,
    tenXa nvarchar(100) not null,
    id_Tinh int not null foreign key references TinhTP(id)
)
create index ix_xa_tinh on XaPhuong(id_Tinh)

create table QuanHe (
    id int identity primary key,
    tenQuanHe nvarchar(50) unique not null
)

-- Insert nhanh mấy cái data quan hệ cơ bản
set identity_insert QuanHe on
insert into QuanHe (id, tenQuanHe) values (1, N'Chủ hộ'), (2, N'Vợ'), (3, N'Chồng'), (4, N'Con'), (5, N'Cháu')
set identity_insert QuanHe off
go

-- 2. DỮ LIỆU NHÂN KHẨU VÀ HỘ KHẨU
create table NhanKhau (
    id int identity primary key,
    soCCCD varchar(12) unique null,
    hoTen nvarchar(100) not null,
    ngaySinh date,
    gioiTinh nvarchar(10),
    id_QueQuan int foreign key references TinhTP(id),
    ngayMat date null,
    isDeleted bit default 0,
    -- Ràng buộc logic
    constraint chk_nk_cccd check (soCCCD is null or soCCCD like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    constraint chk_nk_birth check (ngaySinh <= getdate()),
    constraint chk_nk_death check (ngayMat is null or (ngayMat <= getdate() and ngayMat >= ngaySinh))
)
create index ix_nk_cccd on NhanKhau(soCCCD) where isDeleted = 0

create table HoKhau (
    id int identity primary key,
    maHoKhau varchar(20) unique not null,
    id_Xa int not null foreign key references XaPhuong(id),
    diaChi nvarchar(255),
    ngayLap date default getdate(),
    isDeleted bit default 0
)
create index ix_hk_xa on HoKhau(id_Xa)
go

-- 3. QUẢN LÝ CƯ TRÚ (TIMELINE)
create table LichSuCuTru (
    id int identity primary key,
    id_NK int not null foreign key references NhanKhau(id),
    id_HK int null foreign key references HoKhau(id),
    id_QuanHe int null foreign key references QuanHe(id),
    loaiCuTru nvarchar(50) not null check (loaiCuTru in (N'Thường trú', N'Tạm trú', N'Tạm vắng')),
    tuNgay date not null default getdate(),
    denNgay date null,
    ghiChu nvarchar(255),
    -- Tạm trú/vắng là phải có thời hạn (ngày kết thúc)
    constraint chk_res_date check ((loaiCuTru in (N'Tạm trú', N'Tạm vắng') and denNgay is not null) or (loaiCuTru = N'Thường trú'))
)
-- Index để tránh trùng lặp thường trú và chủ hộ
create unique index ux_active_tt on LichSuCuTru(id_NK) where denNgay is null and loaiCuTru = N'Thường trú'
create unique index ux_active_head on LichSuCuTru(id_HK) where id_QuanHe = 1 and denNgay is null
go

-- 4. BẢO MẬT VÀ TRUY VẾT (AUDIT)
create table TaiKhoan (
    id int identity primary key,
    username varchar(50) unique not null,
    passwordHash varbinary(64) not null, 
    salt uniqueidentifier default newid(),
    role nvarchar(20) default 'Xa' check (role in ('Admin', 'Tinh', 'Xa'))
)

create table AuditLog (
    id int identity primary key,
    tableName varchar(50),
    action varchar(20), 
    recordId int,
    oldData nvarchar(max), 
    newData nvarchar(max), 
    userId int default -1,
    createdAt datetime default getdate()
)
create index ix_audit_lookup on AuditLog(tableName, recordId)
go

-- Proc Login dùng Salted Hash cho bảo mật
create proc sp_Login 
    @user varchar(50), 
    @pass nvarchar(100)
as
begin
    set nocount on
    declare @uid int, @h varbinary(64), @s nvarchar(36)
    select @uid = id, @h = passwordHash, @s = cast(salt as nvarchar(36)) from TaiKhoan where username = @user
    
    if @uid is not null and @h = hashbytes('SHA2_512', @pass + @s)
    begin
        -- Lưu UserId vào context_info (4 byte binary) để Trigger lấy được
        declare @ctx varbinary(128) = cast(@uid as varbinary(128))
        set context_info @ctx
        select 1 as Success, @uid as UserId
    end
    else 
    begin
        set context_info 0x00
        select 0 as Success
    end
end
go

-- 5. CÁC TRIGGER XỬ LÝ NGHIỆP VỤ "KHÓ"
-- Trigger Master: Tự đóng cư trú cũ, check tuổi chủ hộ...
create trigger trg_master_residence on LichSuCuTru after insert
as
begin
    set nocount on
    -- Check tuổi chủ hộ (phải đủ 18 tính theo ngày sinh thực tế)
    if exists (select 1 from inserted i join NhanKhau nk on i.id_NK = nk.id 
               where i.id_QuanHe = 1 and (datediff(day, nk.ngaySinh, i.tuNgay) / 365.2425) < 18)
    begin rollback; throw 50011, N'Chủ hộ phải đủ 18 tuổi!', 1; return; end

    -- Tự động chốt denNgay cho thường trú cũ khi nhập thường trú mới
    if exists (select 1 from inserted where loaiCuTru = N'Thường trú')
        update l set denNgay = dateadd(day, -1, i.tuNgay), ghiChu = N'Chuyển hộ'
        from LichSuCuTru l join inserted i on l.id_NK = i.id_NK
        where l.id <> i.id and l.denNgay is null and l.loaiCuTru = N'Thường trú' and i.loaiCuTru = N'Thường trú'
end
go

-- Trigger bảo vệ dữ liệu (Bio-lock & Soft-delete safety)
create trigger trg_nk_safety on NhanKhau instead of update
as
begin
    set nocount on
    -- Không cho sửa định danh người đã mất
    if exists (select 1 from deleted d join inserted i on d.id = i.id where d.ngayMat is not null and (d.hoTen <> i.hoTen or d.soCCCD <> i.soCCCD))
    begin throw 50005, N'Dữ liệu người đã khuất không được sửa!', 1; return; end

    -- Không cho xóa người đang có tên trong hộ khẩu
    if exists (select 1 from inserted i where i.isDeleted = 1 and exists (select 1 from LichSuCuTru l where l.id_NK = i.id and l.denNgay is null))
    begin throw 50008, N'Phải cắt khẩu trước khi xóa nhân khẩu!', 1; return; end

    update NhanKhau set hoTen = i.hoTen, soCCCD = i.soCCCD, ngaySinh = i.ngaySinh, gioiTinh = i.gioiTinh, ngayMat = i.ngayMat, isDeleted = i.isDeleted from inserted i where NhanKhau.id = i.id
end
go

-- 6. HỆ THỐNG TRUY VẾT (AUDIT) - ĐỦ 3 BẢNG CHÍNH
-- Audit cho NhanKhau
create trigger trg_audit_nk on NhanKhau after insert, update, delete
as
begin
    declare @u_id int = isnull(cast(cast(context_info() as varbinary(4)) as int), -1)
    if exists (select * from inserted) and exists (select * from deleted)
        insert into AuditLog (tableName, action, recordId, oldData, newData, userId)
        select 'NhanKhau', 'UPDATE', i.id, (select * from deleted d where d.id = i.id for xml path('Old'), elements), (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else if exists (select * from inserted)
        insert into AuditLog (tableName, action, recordId, newData, userId)
        select 'NhanKhau', 'INSERT', i.id, (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else
        insert into AuditLog (tableName, action, recordId, oldData, userId)
        select 'NhanKhau', 'DELETE', d.id, (select * from deleted d2 where d2.id = d.id for xml path('Old'), elements), @u_id from deleted d
end
go

-- Audit cho HoKhau
create trigger trg_audit_hk on HoKhau after insert, update, delete
as
begin
    declare @u_id int = isnull(cast(cast(context_info() as varbinary(4)) as int), -1)
    if exists (select * from inserted) and exists (select * from deleted)
        insert into AuditLog (tableName, action, recordId, oldData, newData, userId)
        select 'HoKhau', 'UPDATE', i.id, (select * from deleted d where d.id = i.id for xml path('Old'), elements), (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else if exists (select * from inserted)
        insert into AuditLog (tableName, action, recordId, newData, userId)
        select 'HoKhau', 'INSERT', i.id, (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else
        insert into AuditLog (tableName, action, recordId, oldData, userId)
        select 'HoKhau', 'DELETE', d.id, (select * from deleted d2 where d2.id = d.id for xml path('Old'), elements), @u_id from deleted d
end
go

-- Audit cho LichSuCuTru
create trigger trg_audit_ls on LichSuCuTru after insert, update, delete
as
begin
    declare @u_id int = isnull(cast(cast(context_info() as varbinary(4)) as int), -1)
    if exists (select * from inserted) and exists (select * from deleted)
        insert into AuditLog (tableName, action, recordId, oldData, newData, userId)
        select 'LichSuCuTru', 'UPDATE', i.id, (select * from deleted d where d.id = i.id for xml path('Old'), elements), (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else if exists (select * from inserted)
        insert into AuditLog (tableName, action, recordId, newData, userId)
        select 'LichSuCuTru', 'INSERT', i.id, (select * from inserted ins where ins.id = i.id for xml path('New'), elements), @u_id from inserted i
    else
        insert into AuditLog (tableName, action, recordId, oldData, userId)
        select 'LichSuCuTru', 'DELETE', d.id, (select * from deleted d2 where d2.id = d.id for xml path('Old'), elements), @u_id from deleted d
end
go

-- Seed nhanh data test
declare @s nvarchar(36) = cast(newid() as nvarchar(36))
insert into TaiKhoan (username, passwordHash, salt, role) values ('admin', hashbytes('SHA2_512', N'123456' + @s), cast(@s as uniqueidentifier), 'Admin')
insert into TinhTP (maTinh, tenTinh) values ('001', N'Hà Nội')
insert into XaPhuong (tenXa, id_Tinh) values (N'Đồng Tâm', 1)
go