using QuanLyNhanKhau_Nhom6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNK
{
    public partial class frmLichSuCuTru : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        private Timer timerHK = new Timer();
        private Timer timerNK = new Timer();
        public frmLichSuCuTru()
        {
            InitializeComponent();
        }

        private void HienThiDuLieu()
        {
            // Sử dụng INNER JOIN hoặc LEFT JOIN để lấy thông tin từ các bảng khác
            string sql = @"
                SELECT 
                    ls.id AS [ID],
                    hk.maHoKhau AS [Mã Hộ Khẩu],
                    nk.soCCCD AS [Số CCCD],
                    qh.tenQuanHe AS [Quan Hệ],
                    ls.loaiCuTru AS [Loại Cư Trú],
                    ls.tuNgay AS [Từ Ngày],
                    ls.denNgay AS [Đến Ngày],
                    ls.ghiChu AS [Ghi Chú]
                FROM LichSuCuTru ls
                INNER JOIN NhanKhau nk ON ls.id_NK = nk.id
                INNER JOIN HoKhau hk ON ls.id_HK = hk.id
                INNER JOIN QuanHe qh ON ls.id_QuanHe = qh.id
                ORDER BY ls.id DESC"; // Sắp xếp cái mới nhất lên đầu

            DataTable dta = knn.LayBang(sql);
            dtaLS.DataSource = dta;
        }
        private void Dta_NK()
        {
            DataTable dta = new DataTable();
            dta = knn.LayBang("SELECT soCCCD, hoTen, ngaySinh, gioiTinh FROM NhanKhau");
            dtaNhanKhau.DataSource = dta;
        }
        private void Dta_HK()
        {
            DataTable dta = new DataTable();
            dta = knn.LayBang("SELECT maHoKhau, id_Xa, diaChi FROM HoKhau");
            dtaHoKhau.DataSource = dta;
        }

        private void frmLichSuCuTru_Load(object sender, EventArgs e)
        {
            // Cấu hình Timer cho Hộ Khẩu (độ trễ 300ms)
            timerHK.Interval = 300;
            timerHK.Tick += TimerHK_Tick;

            // Cấu hình Timer cho Nhân Khẩu
            timerNK.Interval = 300;
            timerNK.Tick += TimerNK_Tick;

            // Load dữ liệu ban đầu
            HienThiDuLieu();
            Dta_NK();
            Dta_HK();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ giao diện
                string maHK = txtMHK.Text.Trim();
                string cccd = txtMNK.Text.Trim(); // Giả định bạn nhập CCCD vào txtMNK
                string loaiCuTru = cboLoaiCuTru.Text;
                string quanHe = cboQH.Text;
                string ghiChu = txtNote.Text.Trim();
                string tuNgay = dateStart.Value.ToString("yyyy-MM-dd");

                // Xử lý Ngày kết thúc (Nếu không check thì để NULL)
                string denNgay = dateEnd.Checked ? $"'{dateEnd.Value.ToString("yyyy-MM-dd")}'" : "NULL";

                // 2. Tìm ID tương ứng từ mã/tên (vì bảng trung gian lưu ID int)
                DataTable dtHK = knn.LayBang($"SELECT id FROM HoKhau WHERE maHoKhau = '{maHK}'");
                DataTable dtNK = knn.LayBang($"SELECT id FROM NhanKhau WHERE soCCCD = '{cccd}'");
                DataTable dtQH = knn.LayBang($"SELECT id FROM QuanHe WHERE tenQuanHe = N'{quanHe}'");

                if (dtHK.Rows.Count == 0 || dtNK.Rows.Count == 0 || dtQH.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại Mã Hộ Khẩu, CCCD hoặc Quan Hệ!", "Lỗi nhập liệu");
                    return;
                }

                int id_HK = Convert.ToInt32(dtHK.Rows[0]["id"]);
                int id_NK = Convert.ToInt32(dtNK.Rows[0]["id"]);
                int id_QH = Convert.ToInt32(dtQH.Rows[0]["id"]);

                // 3. Thực thi câu lệnh Insert
                // Lưu ý: Trigger trg_master_residence trong DB của bạn sẽ tự động kiểm tra tuổi 
                // và đóng cư trú cũ nếu đây là 'Thường trú'.
                string sqlInsert = $@"
                    INSERT INTO LichSuCuTru (id_NK, id_HK, id_QuanHe, loaiCuTru, tuNgay, denNgay, ghiChu)
                    VALUES ({id_NK}, {id_HK}, {id_QH}, N'{loaiCuTru}', '{tuNgay}', {denNgay}, N'{ghiChu}')";

                knn.ThucThi(sqlInsert);

                MessageBox.Show("Thêm lịch sử cư trú thành công!", "Thông báo");
                HienThiDuLieu(); // Cập nhật lại GridView
            }
            catch (Exception ex)
            {
                // Thông báo lỗi từ SQL (ví dụ: Chủ hộ chưa đủ 18 tuổi từ Trigger)
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ thống");
            }
        }
        // --- PHẦN HỘ KHẨU ---
        private void txtSearchMHK_TextChanged(object sender, EventArgs e)
        {
            timerHK.Stop();
            timerHK.Start();
        }

        private void TimerHK_Tick(object sender, EventArgs e)
        {
            timerHK.Stop();
            string key = txtSearchMHK.Text.Trim();

            // Sử dụng Parameter để bảo mật SQL Injection
            string sql = "SELECT maHoKhau, id_Xa, diaChi FROM HoKhau WHERE isDeleted = 0 AND maHoKhau LIKE @key";
            SqlParameter[] p = { new SqlParameter("@key", "%" + key + "%") };

            dtaHoKhau.DataSource = knn.ExecuteQuery(sql, p);
        }

        // --- PHẦN NHÂN KHẨU ---
        private void txtSearchMNK_TextChanged(object sender, EventArgs e)
        {
            timerNK.Stop();
            timerNK.Start();
        }

        private void TimerNK_Tick(object sender, EventArgs e)
        {
            timerNK.Stop();
            string key = txtSearchMNK.Text.Trim();

            string sql = "SELECT soCCCD, hoTen, ngaySinh, gioiTinh FROM NhanKhau WHERE isDeleted = 0 AND (soCCCD LIKE @key OR hoTen LIKE @key)";
            SqlParameter[] p = { new SqlParameter("@key", "%" + key + "%") };

            dtaNhanKhau.DataSource = knn.ExecuteQuery(sql, p);
        }
        private void dtaHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMHK.Text = dtaHoKhau.Rows[e.RowIndex].Cells["maHoKhau"].Value.ToString();
            }
        }

        private void dtaNhanKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMNK.Text = dtaNhanKhau.Rows[e.RowIndex].Cells["soCCCD"].Value.ToString();
            }
        }
    }
}
