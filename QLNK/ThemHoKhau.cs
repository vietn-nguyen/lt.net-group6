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
    public partial class ThemHoKhau : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public ThemHoKhau()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            LoadXa();
            LoadTinh();
            LoadHoKhau();
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
        private void comboBox_Tinh_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button_Them_Click(object sender, EventArgs e)
        {

            // 1. Validate
            if (string.IsNullOrWhiteSpace(textBox_Ma_HoKhau.Text))
            {
                MessageBox.Show("Chưa nhập mã hộ khẩu");
                return;
            }

            if (comboBox_Xa.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn xã");
                return;
            }

            // 2. Lấy dữ liệu
            string maHoKhau = textBox_Ma_HoKhau.Text.Trim();
            string diaChi = textBox_DiaChi.Text.Trim();
            int idXa = Convert.ToInt32(comboBox_Xa.SelectedValue);

            // 3. Query
            string query = @"
            INSERT INTO HoKhau (maHoKhau, diaChi,id_Xa)
            VALUES (@ma, @dc, @xa)
             ";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ma", maHoKhau),
            new SqlParameter("@dc", diaChi),
            new SqlParameter("@xa", idXa)
            };

            int result = knn.ExecuteNonQuery(query, parameters);

            // 4. Result
            if (result > 0)
            {
                MessageBox.Show("Thêm thành công");
                LoadHoKhau();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
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
