using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanKhau_Nhom6;

namespace QLNK
{
    public partial class frmTimKiemTamVang : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();

        private void TimKiem()
        {
            string cccd = txtCCCD.Text;

            // SQL ADJUSTED FOR NEW DATABASE SCHEMA:
            // Lọc loaiCuTru = N'Tạm vắng' và denNgay >= Ngày hiện tại (đang hiệu lực)
            string sql = $@"
                SELECT 
                    nk.soCCCD AS [Số CCCD],
                    nk.hoTen AS [Họ và Tên],
                    nk.ngaySinh AS [Ngày Sinh],
                    ls.tuNgay AS [Ngày Bắt Đầu],
                    ls.denNgay AS [Ngày Kết Thúc],
                    ls.ghiChu AS [Lý Do / Ghi Chú]
                FROM NhanKhau nk
                INNER JOIN LichSuCuTru ls ON nk.id = ls.id_NK
                WHERE nk.isDeleted = 0 
                AND ls.loaiCuTru = N'Tạm vắng'
                AND (ls.denNgay IS NULL OR ls.denNgay >= GETDATE())
                AND (nk.soCCCD LIKE '%{cccd}%' OR '{cccd}' = '')";

            try
            {
                DataTable dt = knn.LayBang(sql);
                dtaKetQua.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Thông báo");
            }
        }
        public frmTimKiemTamVang()
        {
            InitializeComponent();
        }

        private void frmTimKiemTamVang_Load(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
