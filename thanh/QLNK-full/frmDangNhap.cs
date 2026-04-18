using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    public partial class frmDangNhap : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtTaiKhoan.Text.Trim();
                string pass = txtMatKhau.Text.Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo");
                    return;
                }

                SqlParameter[] p = {
                    new SqlParameter("@user", user),
                    new SqlParameter("@pass", pass)
                };

                DataTable dt = knn.LayDuLieuTuProc("sp_Login", p);

                if (dt.Rows.Count > 0 && dt.Rows[0]["Success"].ToString() == "1")
                {
                    UserSession.CurrentUserId = Convert.ToInt32(dt.Rows[0]["UserId"]);

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    frmMain fMain = new frmMain();
                    this.Hide();
                    fMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }
    }
}