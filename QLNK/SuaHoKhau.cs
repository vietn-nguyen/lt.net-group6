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
    public partial class SuaHoKhau : Form
    {

        KETNOI_CSDL knn = new KETNOI_CSDL();

        int? _selectedId = null;
        public SuaHoKhau()
        {
            InitializeComponent();
            Edit_Load(null, null);
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

        private void Edit_Load(object sender, EventArgs e)
        {
            LoadXa();
            LoadTinh();
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBox_Tinh.SelectedValue is int idTinh)) return;


            string query = $@"
             SELECT id, tenXa 
             FROM XaPhuong
             WHERE id_Tinh = {idTinh}
             ";

            comboBox_Xa.DataSource = knn.ExecuteQuery(query);
            comboBox_Xa.DisplayMember = "tenXa";
            comboBox_Xa.ValueMember = "id";
        }

        private void comboBox_Xa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadHoKhau()
        {
            string query = "SELECT * FROM HoKhau WHERE isDeleted=0";
            DataTable dt = knn.ExecuteQuery(query);
            dataGridView_HoKhau.DataSource = dt;
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            // 1. Check có chọn dòng chưa
            if (_selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn hộ khẩu cần sửa");
                return;
            }

            // 2. Lấy dữ liệu từ form
            string maHoKhau = textBox_Ma_HoKhau.Text.Trim();
            string diaChi = textBox_DiaChi.Text.Trim();
            DateTime ngayLap = dateTimePicker_NgayLap.Value;

            if (!(comboBox_Xa.SelectedValue is int idXa))
            {
                MessageBox.Show("Vui lòng chọn Xã");
                return;
            }

            // 3. Validate
            if (string.IsNullOrEmpty(maHoKhau))
            {
                MessageBox.Show("Mã hộ khẩu không được để trống");
                return;
            }

            if (string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }

            // 4. Update DB
            string query = @"
                UPDATE HoKhau
                SET maHoKhau = @maHoKhau,
                    diaChi   = @diaChi,
                    ngayLap  = @ngayLap,
                    id_Xa    = @idXa
                WHERE id = @id
            ";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@maHoKhau", maHoKhau),
                new SqlParameter("@diaChi", diaChi),
                new SqlParameter("@ngayLap", ngayLap),
                new SqlParameter("@idXa", idXa),
                new SqlParameter("@id", _selectedId)
            };

            int result = knn.ExecuteNonQuery(query, parameters);

            // 5. Kết quả
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công");

                LoadHoKhau(); // reload lại DataGridView
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
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
