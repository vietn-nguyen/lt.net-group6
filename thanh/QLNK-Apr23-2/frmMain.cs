using BTN;
using CrystalDecisions.CrystalReports.Engine;
using QLNK;
using QuanLyNhanKhau_Nhom6;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    public partial class frmMain : Form
    {
        public frmMain(string tenNguoiDung = "")
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(tenNguoiDung))
            {
                lblTenTaiKhoan.Text = tenNguoiDung;
            }
        }

        private void nhânKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frmNhanKhau"];
            if (frm == null)
            {
                frmNhanKhau f = new frmNhanKhau();
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
        private void btnBCTamTru_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhanKhauTinh;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);

                string sql = @"
        SELECT 
            TinhTP.tenTinh AS TenKhuVuc,
            COUNT(NhanKhau.id) AS TongSoDan,
            SUM(CASE WHEN NhanKhau.gioiTinh = N'Nam' THEN 1 ELSE 0 END) AS SoNam,
            SUM(CASE WHEN NhanKhau.gioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS SoNu
        FROM NhanKhau
        INNER JOIN LichSuCuTru ON NhanKhau.id = LichSuCuTru.id_NK
        INNER JOIN HoKhau ON LichSuCuTru.id_HK = HoKhau.id 
        INNER JOIN XaPhuong ON HoKhau.id_Xa = XaPhuong.id
        INNER JOIN TinhTP ON XaPhuong.id_Tinh = TinhTP.id
        WHERE LichSuCuTru.denNgay IS NULL 
        GROUP BY TinhTP.tenTinh";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ReportDocument rpt = new ReportDocument();
                string duongDan = Application.StartupPath + "\\rptThongKe.rpt";
                rpt.Load(duongDan);

                rpt.SetDataSource(dt);

                frmHienThiBaoCao f = new frmHienThiBaoCao();
                f.crystalReportViewer1.ReportSource = rpt;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnBCNhanKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhanKhauTinh;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);

                // Câu lệnh SQL lấy dữ liệu đổ vào dtNhanKhau
                // Tên cột sau chữ "AS" phải khớp 100% với tên cột bạn tạo trong DataSet (.xsd)
                string sql = @"
SELECT 
    nk.hoTen AS HoTen, 
    nk.soCCCD AS SoCCCD, 
    nk.ngaySinh AS NgaySinh, 
    nk.gioiTinh AS GioiTinh,
    t_que.tenTinh AS QueQuan,
    xp.tenXa AS XaPhuong,
    CASE 
        WHEN nk.ngayMat IS NOT NULL THEN N'Đã mất'
        WHEN nk.isDeleted = 1 THEN N'Đã xóa'
        ELSE N'Đang cư trú'
    END AS TrangThai
FROM NhanKhau nk
LEFT JOIN TinhTP t_que ON nk.id_QueQuan = t_que.id
LEFT JOIN LichSuCuTru ls ON nk.id = ls.id_NK AND ls.denNgay IS NULL
LEFT JOIN HoKhau hk ON ls.id_HK = hk.id
LEFT JOIN XaPhuong xp ON hk.id_Xa = xp.id
WHERE nk.isDeleted = 0";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Khởi tạo báo cáo
                ReportDocument rpt = new ReportDocument();
                // Đảm bảo file .rpt này đã được chỉnh 'Copy to Output Directory' là 'Copy always'
                string duongDan = Application.StartupPath + "\\rptNhanKhau.rpt";
                rpt.Load(duongDan);

                rpt.SetDataSource(dt);

                // Hiển thị lên Form báo cáo
                frmHienThiBaoCao f = new frmHienThiBaoCao();
                f.crystalReportViewer1.ReportSource = rpt;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnBCDanCu_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhanKhauTinh;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);

                string sql = @"
        SELECT 
            TinhTP.tenTinh AS TenKhuVuc,
            NhanKhau.hoTen AS HoTen,
            NhanKhau.soCCCD AS CCCD,
            LichSuCuTru.loaiCuTru AS LoaiCuTru
        FROM LichSuCuTru 
        INNER JOIN NhanKhau ON LichSuCuTru.id_NK = NhanKhau.id 
        INNER JOIN HoKhau ON LichSuCuTru.id_HK = HoKhau.id 
        INNER JOIN XaPhuong ON HoKhau.id_Xa = XaPhuong.id
        INNER JOIN TinhTP ON XaPhuong.id_Tinh = TinhTP.id 
        WHERE LichSuCuTru.loaiCuTru IN (N'Thường trú', N'Tạm trú', N'Tạm vắng')";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ReportDocument rpt = new ReportDocument();
                string duongDan = Application.StartupPath + "\\rptTamTru.rpt";
                rpt.Load(duongDan);

                rpt.SetDataSource(dt);

                frmHienThiBaoCao f = new frmHienThiBaoCao();
                f.crystalReportViewer1.ReportSource = rpt;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // 1. Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Tuyệt chiêu: Khởi động lại toàn bộ phần mềm
                Application.Restart();
            }
        }
     }
}
