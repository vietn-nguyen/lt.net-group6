using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            Application.Exit();
        }

        private void nhânKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frmTimKiemNhanKhau"];
            if (frm == null)
            {
                frmTimKiemNhanKhau f = new frmTimKiemNhanKhau();
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void báoCáoTạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Thay chuỗi kết nối của bạn vào đây
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
                WHERE LichSuCuTru.loaiCuTru IN (N'Tạm trú', N'Tạm vắng')";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gọi file thiết kế và nhồi dữ liệu vào
                rptTamTru rpt = new rptTamTru();
                rpt.SetDataSource(dt);

                // Hiển thị lên Form
                frmHienThiBaoCao f = new frmHienThiBaoCao();
                f.crystalReportViewer1.ReportSource = rpt;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Thay chuỗi kết nối của bạn vào đây
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
                WHERE LichSuCuTru.denNgay IS NULL -- Chỉ đếm những người đang cư trú hiện tại
                GROUP BY TinhTP.tenTinh";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptThongKe rpt = new rptThongKe();
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
    }
}