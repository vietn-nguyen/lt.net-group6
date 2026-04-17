using BTN;
using QLNK;
using System;
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
    }
}