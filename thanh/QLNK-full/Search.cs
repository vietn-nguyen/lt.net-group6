using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanKhau_Nhom6;


namespace BTN
{
    public partial class Search : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public Search()
        {
            InitializeComponent();
            Search_Load(null, null);
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
            string query = @"
        SELECT 
            hk.id,
            hk.maHoKhau,
            hk.diaChi,
            hk.ngayLap,
            x.tenXa,
            t.tenTinh
        FROM HoKhau hk
        JOIN XaPhuong x ON hk.id_Xa = x.id
        JOIN TinhTP t ON x.id_Tinh = t.id
        WHERE hk.isDeleted = 0
    ";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // 1. filter mã hộ khẩu
            if (!string.IsNullOrWhiteSpace(textBox_Ma_HoKhau.Text))
            {
                query += " AND hk.maHoKhau LIKE @ma";
                parameters.Add(new SqlParameter("@ma", "%" + textBox_Ma_HoKhau.Text + "%"));
            }

            // 2. filter địa chỉ
            if (!string.IsNullOrWhiteSpace(textBox_DiaChi.Text))
            {
                query += " AND hk.diaChi LIKE @dc";
                parameters.Add(new SqlParameter("@dc", "%" + textBox_DiaChi.Text + "%"));
            }

            // 3. filter tỉnh
            if (comboBox_Tinh.SelectedValue != null && comboBox_Tinh.SelectedIndex != -1)
            {
                query += " AND t.id = @tinh";
                parameters.Add(new SqlParameter("@tinh", comboBox_Tinh.SelectedValue));
            }

            // 4. filter xã
            if (comboBox_Xa.SelectedValue != null && comboBox_Xa.SelectedIndex != -1)
            {
                query += " AND hk.id_Xa = @xa";
                parameters.Add(new SqlParameter("@xa", comboBox_Xa.SelectedValue));
            }

            // 5. filter ngày lập (from - to)
            if (dateTimePicker_Tu.Checked)
            {
                query += " AND hk.ngayLap >= @from";
                parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value.Date));
            }

            if (dateTimePicker_Den.Checked)
            {
                query += " AND hk.ngayLap <= @to";
                parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value.Date));
            }

            // execute
            dataGridView_HoKhau.DataSource =
                knn.ExecuteQuery(query, parameters.ToArray());
        }
        private void Search_Load(object sender, EventArgs e)
        {
            LoadXa();
            LoadTinh();
            LoadHoKhau();
        }
        private void button_TimKiem_Click(object sender, EventArgs e)
        {

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
