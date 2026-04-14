using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    public partial class frmTimKiemNhanKhau : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public frmTimKiemNhanKhau()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTuKhoa.Text.Trim();
                string tieuChi = cboTieuChi.Text;

                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa cần tìm.");
                    return;
                }

                string sql = "SELECT * FROM NhanKhau WHERE isDeleted = 0 AND ";

                if (tieuChi == "Số CCCD")
                {
                    sql += $"soCCCD LIKE '%{tuKhoa}%'";
                }
                else
                {
                    sql += $"hoTen LIKE N'%{tuKhoa}%'";
                }

                DataTable dt = knn.LayBang(sql);

                if (dt.Rows.Count > 0)
                {
                    dtaKetQua.DataSource = dt;
                }
                else
                {
                    dtaKetQua.DataSource = null;
                    MessageBox.Show("Không tìm thấy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void frmTimKiemNhanKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
