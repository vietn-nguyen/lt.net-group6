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
    public partial class TimKiemTamTru : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public TimKiemTamTru()
        {
            InitializeComponent();
        }

        private void TimKiemTamTru_Load(object sender, EventArgs e)
        {

        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder query = new StringBuilder(@"
                SELECT TOP 100
                    l.id,
                    nk.hoTen,
                    nk.soCCCD,
                    hk.maHoKhau,
                    l.tuNgay,
                    l.denNgay,
                    l.ghiChu
                FROM LichSuCuTru l
                JOIN NhanKhau nk ON nk.id = l.id_NK
                LEFT JOIN HoKhau hk ON hk.id = l.id_HK
                WHERE l.loaiCuTru = N'Tạm trú'
                ");

                List<SqlParameter> parameters = new List<SqlParameter>();


                string key = textBox_HoTen.Text.Trim();
                if (!string.IsNullOrEmpty(key))
                {
                    query.Append(" AND nk.hoTen LIKE @key");
                    parameters.Add(new SqlParameter("@key", "%" + key + "%"));
                }
                string cccd = textBox_SoCCCD.Text.Trim();
                if (!string.IsNullOrEmpty(cccd))
                {
                    query.Append(" AND nk.soCCCD LIKE @cccd");
                    parameters.Add(new SqlParameter("@cccd", "%" + cccd + "%"));
                }

                string maHK = textBox_MaHoKhau.Text.Trim();
                if (!string.IsNullOrEmpty(maHK))
                {
                    query.Append(" AND hk.maHoKhau LIKE @maHK");
                    parameters.Add(new SqlParameter("@maHK", "%" + maHK + "%"));
                }


                if (dateTimePicker_Tu.Checked)
                {
                    query.Append(" AND l.tuNgay >= @from");
                    parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value.Date));
                }

                if (dateTimePicker_Den.Checked)
                {
                    query.Append(" AND l.denNgay <= @to");
                    parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value.Date));
                }


                query.Append(" ORDER BY l.tuNgay DESC");

                var dt = knn.ExecuteQuery(query.ToString(), parameters.ToArray());

                dataGridView_TamTru.DataSource = dt;


                dataGridView_TamTru.Columns["id"].Visible = false;
                dataGridView_TamTru.Columns["hoTen"].HeaderText = "Họ tên";
                dataGridView_TamTru.Columns["soCCCD"].HeaderText = "CCCD";
                dataGridView_TamTru.Columns["maHoKhau"].HeaderText = "Mã hộ khẩu";
                dataGridView_TamTru.Columns["tuNgay"].HeaderText = "Từ ngày";
                dataGridView_TamTru.Columns["denNgay"].HeaderText = "Đến ngày";
                dataGridView_TamTru.Columns["ghiChu"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button_DatLai_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. clear text
                textBox_HoTen.Clear();
                textBox_SoCCCD.Clear();
                textBox_MaHoKhau.Clear();

                // 2. reset DateTimePicker
                dateTimePicker_Tu.Value = DateTime.Now;
                dateTimePicker_Den.Value = DateTime.Now;

                dateTimePicker_Tu.Checked = false;
                dateTimePicker_Den.Checked = false;

                // 3. clear DataGridView
                dataGridView_TamTru.DataSource = null;
                dataGridView_TamTru.Rows.Clear();

                // 4. optional: focus lại ô đầu
                textBox_HoTen.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reset: " + ex.Message);
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
