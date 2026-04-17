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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QuanLyNhanKhau_Nhom6;

namespace BTN
{
    public partial class TimKiemLichSuCuTru : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public TimKiemLichSuCuTru()
        {
            InitializeComponent();
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
        private void LoadLoaiCuTru()
        {
            comboBox_LoaiCuTru.Items.Clear();
            comboBox_LoaiCuTru.Items.Add("Thường trú");
            comboBox_LoaiCuTru.Items.Add("Tạm trú");
            comboBox_LoaiCuTru.Items.Add("Tạm vắng");

            // chọn mặc định
            comboBox_LoaiCuTru.SelectedIndex = -1;
        }
        private void LoadLichSuCuTru()
        {

            string query = @"
            SELECT 
                nk.hoTen,
                nk.soCCCD,
                hk.maHoKhau,
                x.tenXa,
                t.tenTinh,
                l.loaiCuTru,
                l.tuNgay,
                l.denNgay
            FROM LichSuCuTru l
            JOIN NhanKhau nk ON nk.id = l.id_NK
            LEFT JOIN HoKhau hk ON hk.id = l.id_HK
            LEFT JOIN XaPhuong x ON x.id = hk.id_Xa
            LEFT JOIN TinhTP t ON t.id = x.id_Tinh
            WHERE nk.isDeleted = 0
            ";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // 1. filter họ tên
            if (!string.IsNullOrWhiteSpace(textBox_HoTen.Text))
            {
                query += " AND nk.hoTen LIKE @name";
                parameters.Add(new SqlParameter("@name", "%" + textBox_HoTen.Text + "%"));
            }

            // 2. filter CCCD
            if (!string.IsNullOrWhiteSpace(textBox_SoCCCD.Text))
            {
                query += " AND nk.soCCCD = @cccd";
                parameters.Add(new SqlParameter("@cccd", textBox_SoCCCD.Text));
            }

            // 3. filter mã hộ khẩu
            if (!string.IsNullOrWhiteSpace(textBox_MaHoKhau.Text))
            {
                query += " AND hk.maHoKhau LIKE @maHK";
                parameters.Add(new SqlParameter("@maHK", "%" + textBox_MaHoKhau.Text + "%"));
            }

            // 4. filter loại cư trú
            if (comboBox_LoaiCuTru.SelectedIndex != -1)
            {
                query += " AND l.loaiCuTru = @loai";
                parameters.Add(new SqlParameter("@loai", comboBox_LoaiCuTru.Text));
            }

            // 5. filter tỉnh
            if (comboBox_Tinh.SelectedValue != null && comboBox_Tinh.SelectedIndex != -1)
            {
                query += " AND t.id = @tinh";
                parameters.Add(new SqlParameter("@tinh", comboBox_Tinh.SelectedValue));
            }

            // 6. filter xã
            if (comboBox_Xa.SelectedValue != null && comboBox_Xa.SelectedIndex != -1)
            {
                query += " AND x.id = @xa";
                parameters.Add(new SqlParameter("@xa", comboBox_Xa.SelectedValue));
            }

            // 7. filter khoảng thời gian (chuẩn timeline)
            if (dateTimePicker_Tu.Checked && dateTimePicker_Den.Checked)
            {
                query += @"
                AND (
                    l.tuNgay >= @from
                    AND (l.denNgay IS NULL OR l.denNgay <= @to)
                )";
                parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value.Date));
                parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value.Date));
            }
            else if (dateTimePicker_Tu.Checked)
            {
                query += " AND l.tuNgay >= @from";
                parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value.Date));
            }
            else if (dateTimePicker_Den.Checked)
            {
                query += @"
                AND (
                    l.tuNgay <= @to
                    AND (l.denNgay IS NULL OR l.denNgay >= @to)
                )";
                parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value.Date));
            }

            // sort
            query += " ORDER BY nk.id, l.tuNgay DESC";

            // execute
            dataGridView_LichSuCuTru.DataSource =
                knn.ExecuteQuery(query, parameters.ToArray());
            dataGridView_LichSuCuTru.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView_LichSuCuTru.Columns["soCCCD"].HeaderText = "Số CCCD";
            dataGridView_LichSuCuTru.Columns["maHoKhau"].HeaderText = "Mã hộ khẩu";
            dataGridView_LichSuCuTru.Columns["tenXa"].HeaderText = "Xã/Phường";
            dataGridView_LichSuCuTru.Columns["tenTinh"].HeaderText = "Tỉnh/Thành phố";
            dataGridView_LichSuCuTru.Columns["loaiCuTru"].HeaderText = "Loại cư trú";
            dataGridView_LichSuCuTru.Columns["tuNgay"].HeaderText = "Từ ngày";
            dataGridView_LichSuCuTru.Columns["denNgay"].HeaderText = "Đến ngày";

            dataGridView_LichSuCuTru.Columns["tuNgay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_LichSuCuTru.Columns["denNgay"].DefaultCellStyle.Format = "dd/MM/yyyy";

            //dataGridView_LichSuCuTru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_LichSuCuTru.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void TimKiemLichSuCuTru_Load(object sender, EventArgs e)
        {
            LoadXa();
            LoadTinh();
            LoadLoaiCuTru();
        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            LoadLichSuCuTru();
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

        private void button_DatLai_Click(object sender, EventArgs e)
        {
            // 1. TextBox
            textBox_HoTen.Clear();
            textBox_SoCCCD.Clear();
            textBox_MaHoKhau.Clear();

            // 2. ComboBox
            comboBox_LoaiCuTru.SelectedIndex = -1;
            comboBox_Tinh.SelectedIndex = -1;
            comboBox_Xa.DataSource = null;
            comboBox_Xa.Items.Clear();

            // 3. DateTimePicker (QUAN TRỌNG)
            dateTimePicker_Tu.Checked = false;
            dateTimePicker_Den.Checked = false;

            // reset về giá trị mặc định (tránh giữ value cũ)
            dateTimePicker_Tu.Value = DateTime.Today;
            dateTimePicker_Den.Value = DateTime.Today;

            // 4. Load lại dữ liệu full
            LoadLichSuCuTru();
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
