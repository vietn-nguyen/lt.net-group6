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
    }
}