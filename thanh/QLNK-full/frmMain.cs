using BTN;
using CrystalDecisions.CrystalReports.Engine;
using QLNK;
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

        private void hộKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạmVắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTamVang f = new frmTamVang();
            f.Show();
        }

        private void thêmHộKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemHoKhau f = new ThemHoKhau();
            f.Show();
        }

        private void sửaHộKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaHoKhau f = new SuaHoKhau();
            f.Show();
        }

        private void xóaHộKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaHoKhau f = new XoaHoKhau();
            f.Show();
        }

        private void thêmTạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTamTru f = new ThemTamTru();
            f.Show();
        }

        private void sửaTạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaTamTru f = new SuaTamTru();
            f.Show();
        }

        private void xóaTạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaTamTru f = new XoaTamTru();
            f.Show();
        }

        private void hộKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTimKiemHoKhau f = new frmTimKiemHoKhau();
            f.Show();
        }

        private void tạmTrúToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimKiemTamTru f = new TimKiemTamTru();
            f.Show();
        }

        private void tạmVắngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTimKiemTamVang f = new frmTimKiemTamVang();
            f.Show();
        }

        private void thayĐổiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search f = new Search();
            f.Show();
        }

        private void lịchSửCưTrúToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimKiemLichSuCuTru f = new TimKiemLichSuCuTru();
            f.Show();
        }

        private void nhậtKýTruyVếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemNhatKyTruyVet f = new TimKiemNhatKyTruyVet();
            f.Show();
        }

        private void lịchSửCưTrúToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmLichSuCuTru f = new frmLichSuCuTru();
            f.Show();
        }

        private void báoCáoTạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
 }