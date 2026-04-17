using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    public partial class frmNhanKhau : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();

        public frmNhanKhau()
        {
            InitializeComponent();
        }

        // --- 1. HÀM TẢI DỮ LIỆU ---

        private void Load_QueQuan()
        {
            try
            {
                DataTable dt = knn.LayBang("SELECT id, tenTinh FROM TinhTP");
                cboQueQuan.DataSource = dt;
                cboQueQuan.DisplayMember = "tenTinh";
                cboQueQuan.ValueMember = "id";
                cboQueQuan.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Load Quê quán: " + ex.Message); }
        }

        private void Load_BangNhanKhau()
        {
            try
            {
                DataTable dt = knn.LayBang("SELECT * FROM NhanKhau WHERE isDeleted = 0");
                dtaNhanKhau.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Load Bảng: " + ex.Message); }
        }

        // --- 2. SỰ KIỆN FORM LOAD ---

        private void frmNhanKhau_Load(object sender, EventArgs e)
        {
            Load_QueQuan();
            Load_BangNhanKhau();
        }

        // --- 3. CÁC NÚT CHỨC NĂNG ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCCCD.Text) || string.IsNullOrEmpty(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Số CCCD và Họ tên!");
                    return;
                }

                string id_que = cboQueQuan.SelectedValue != null
                    ? cboQueQuan.SelectedValue.ToString() : "NULL";
                string ngaymat = dtpNgayMat.Checked
                    ? $"'{dtpNgayMat.Value:yyyy-MM-dd}'" : "NULL";

                string sql = $@"INSERT INTO NhanKhau (soCCCD, hoTen, ngaySinh, gioiTinh, id_QueQuan, ngayMat, isDeleted)
                                VALUES ('{txtCCCD.Text}', N'{txtHoTen.Text}', '{dtpNgaySinh.Value:yyyy-MM-dd}',
                                N'{cboGioiTinh.Text}', {id_que}, {ngaymat}, 0)";

                knn.ThucThi(sql);
                Load_BangNhanKhau();
                MessageBox.Show("Thêm nhân khẩu thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi Thêm: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text)) return;

                string id_que = cboQueQuan.SelectedValue != null
                    ? cboQueQuan.SelectedValue.ToString() : "NULL";
                string ngaymat = dtpNgayMat.Checked
                    ? $"'{dtpNgayMat.Value:yyyy-MM-dd}'" : "NULL";

                string sql = $@"UPDATE NhanKhau
                                SET soCCCD='{txtCCCD.Text}', hoTen=N'{txtHoTen.Text}',
                                    ngaySinh='{dtpNgaySinh.Value:yyyy-MM-dd}',
                                    gioiTinh=N'{cboGioiTinh.Text}',
                                    id_QueQuan={id_que}, ngayMat={ngaymat}
                                WHERE id={txtID.Text}";

                knn.ThucThi(sql);
                Load_BangNhanKhau();
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi Sửa: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text)) return;

                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhân khẩu này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    knn.ThucThi($"UPDATE NhanKhau SET isDeleted = 1 WHERE id = {txtID.Text}");
                    Load_BangNhanKhau();
                    btnLamMoi_Click(sender, e);
                    MessageBox.Show("Đã xóa nhân khẩu!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi Xóa: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtCCCD.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboQueQuan.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayMat.Checked = false;
            Load_BangNhanKhau();
        }

        private void dtaNhanKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtaNhanKhau.Rows[e.RowIndex];

                txtID.Text = row.Cells["id"].Value.ToString();
                txtCCCD.Text = row.Cells["soCCCD"].Value.ToString();
                txtHoTen.Text = row.Cells["hoTen"].Value.ToString();
                cboGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
                cboQueQuan.SelectedValue = row.Cells["id_QueQuan"].Value;

                if (row.Cells["ngaySinh"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value);

                if (row.Cells["ngayMat"].Value != DBNull.Value)
                {
                    dtpNgayMat.Checked = true;
                    dtpNgayMat.Value = Convert.ToDateTime(row.Cells["ngayMat"].Value);
                }
                else
                {
                    dtpNgayMat.Checked = false;
                }
            }
        }
    }
}