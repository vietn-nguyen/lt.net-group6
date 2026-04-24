using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhanKhau_Nhom6;

namespace QLNK
{
    public partial class frmTimKiemHoKhau : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public frmTimKiemHoKhau()
        {
            InitializeComponent();
        }

        private void HienThiDuLieu()
        {
            // Lấy giá trị từ các điều khiển và xử lý dấu nháy đơn để tránh lỗi SQL
            string maHK = txtMaHK.Text.Trim().Replace("'", "''");
            string cccd = txtCCCDChuHo.Text.Trim().Replace("'", "''");
            string tinh = cboTinh.Text.Trim().Replace("'", "''");
            string xa = cboXa.Text.Trim().Replace("'", "''");
            string diaChi = txtDiaChi.Text.Trim().Replace("'", "''");

            // Câu lệnh truy vấn SQL Join các bảng liên quan
            string sql = $@"
                SELECT 
                    hk.maHoKhau AS [Mã Hộ Khẩu],
                    nk.hoTen AS [Tên Chủ Hộ],
                    nk.soCCCD AS [CCCD Chủ Hộ],
                    tp.tenTinh AS [Tỉnh/TP],
                    xp.tenXa AS [Xã/Phường],
                    hk.diaChi AS [Địa Chỉ],
                    hk.ngayLap AS [Ngày Lập]
                FROM HoKhau hk
                INNER JOIN XaPhuong xp ON hk.id_Xa = xp.id
                INNER JOIN TinhTP tp ON xp.id_Tinh = tp.id
                -- Lấy thông tin chủ hộ (người có id_QuanHe = 1 và còn đang hoạt động)
                LEFT JOIN LichSuCuTru ls ON hk.id = ls.id_HK AND ls.id_QuanHe = 1 AND ls.denNgay IS NULL
                LEFT JOIN NhanKhau nk ON ls.id_NK = nk.id
                WHERE hk.isDeleted = 0
                AND hk.maHoKhau LIKE '%{maHK}%'
                AND (nk.soCCCD LIKE '%{cccd}%' OR nk.soCCCD IS NULL)
                AND tp.tenTinh LIKE N'%{tinh}%'
                AND xp.tenXa LIKE N'%{xa}%'
                AND hk.diaChi LIKE N'%{diaChi}%'";

            try
            {
                DataTable dt = knn.LayBang(sql);
                dtaKetQua.DataSource = dt;

                if (dt.Rows.Count == 0 && (maHK != "" || cccd != ""))
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi kết nối");
            }
        }
        private void frmTimKiemHoKhau_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }
    }
}
