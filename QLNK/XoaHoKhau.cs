using System.Data.SqlClient;
using QuanLyNhanKhau_Nhom6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN
{
    public partial class XoaHoKhau : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();

        int? _selectedId = null;
        public XoaHoKhau()
        {
            InitializeComponent();
            Delete_Load(null, null);
        }

        private void LoadXa()
        {
            string query = @"
            SELECT id, tenXa 
            FROM XaPhuong 
            ";

            var dt = knn.ExecuteQuery(query);

            comboBox_Xa.DataSource = dt;
            comboBox_Xa.DisplayMember = "tenXa"; // text hiển thị
            comboBox_Xa.ValueMember = "id";      // giá trị thật

            comboBox_Xa.SelectedIndex = -1;
        }
        private void LoadTinh()
        {
            string query = @"
            SELECT id, tenTinh
            FROM TinhTP
            ";

            var dt = knn.ExecuteQuery(query);

            comboBox_Tinh.DataSource = dt;
            comboBox_Tinh.DisplayMember = "tenTinh"; // text hiển thị
            comboBox_Tinh.ValueMember = "id";      // giá trị thật

            comboBox_Tinh.SelectedIndex = -1;
        }
        private void LoadHoKhau()
        {
            string query = "SELECT * FROM HoKhau WHERE isDeleted=0";
            DataTable dt = knn.ExecuteQuery(query);
            dataGridView_HoKhau.DataSource = dt;
        }
        private void Delete_Load(object sender, EventArgs e)
        {
            LoadXa();
            LoadTinh();
            LoadHoKhau();
        }

        private void dataGridView_HoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // tránh click header bị lỗi
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView_HoKhau.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            _selectedId = Convert.ToInt32(row.Cells["id"].Value);
            textBox_Ma_HoKhau.Text = row.Cells["maHoKhau"].Value?.ToString();
            textBox_DiaChi.Text = row.Cells["diaChi"].Value?.ToString();

            dateTimePicker_NgayLap.Value = row.Cells["ngayLap"].Value != DBNull.Value
                ? Convert.ToDateTime(row.Cells["ngayLap"].Value)
                : DateTime.Now;

            int idXa = Convert.ToInt32(row.Cells["id_Xa"].Value);
            string query = $@"
            SELECT x.id_Tinh, t.tenTinh
            FROM XaPhuong x
            JOIN TinhTP t ON t.id = x.id_Tinh
            WHERE x.id = {idXa}
            ";

            var dt = knn.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                int idTinh = Convert.ToInt32(dt.Rows[0]["id_Tinh"]);

                comboBox_Tinh.SelectedValue = idTinh; // set tỉnh trước
                comboBox_Xa.SelectedValue = idXa;     // set xã sau
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra đã chọn chưa
                if (_selectedId == 0)
                {
                    MessageBox.Show("Vui lòng chọn hộ khẩu cần xóa!");
                    return;
                }

                // 2. Confirm
                var result = MessageBox.Show(
                    "Bạn có chắc muốn xóa hộ khẩu này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                // 3. Query soft delete
                string query = @"
            UPDATE HoKhau
            SET isDeleted = 1
            WHERE id = @id";

                var parameters = new[]
                {
            new SqlParameter("@id", _selectedId)
        };

                // 4. Execute
                int rows = knn.ExecuteNonQuery(query, parameters);

                if (rows > 0)
                {
                    MessageBox.Show("Xóa thành công!");

                    // 5. Reload grid
                    LoadHoKhau();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu để xóa!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Bạn có chắc muốn thoát không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
