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
    public partial class SuaTamTru : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        private System.Windows.Forms.Timer searchTimer;
        private int selectedNhanKhauId = -1;
        private int selectedTamTruId = -1;
        public SuaTamTru()
        {
            InitializeComponent();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += searchTimer_Tick;
        }

        private void textBox_TimKiemTamTru_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            string key = textBox_TimKiemTamTru.Text.Trim();

            if (string.IsNullOrEmpty(key))
            {
                dataGridView_NhanKhau.Visible = false;
                return;
            }

            string query = @"
            SELECT TOP 10
                id,
                hoTen,
                soCCCD
            FROM NhanKhau
            WHERE isDeleted = 0
              AND (hoTen LIKE @key OR soCCCD LIKE @key)
            ORDER BY hoTen
            ";

            var dt = knn.ExecuteQuery(
                query,
                new SqlParameter[]
                {
            new SqlParameter("@key", "%" + key + "%")
                }
            );

            dataGridView_NhanKhau.DataSource = dt;

            // format UI
            dataGridView_NhanKhau.Columns["id"].Visible = false;
            dataGridView_NhanKhau.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView_NhanKhau.Columns["soCCCD"].HeaderText = "CCCD";

            dataGridView_NhanKhau.Visible = dt.Rows.Count > 0;
        }
        private void LoadTamTruByNhanKhau(int idNK)
        {
            string query = @"
            SELECT 
                hk.maHoKhau,
                l.id,
                l.loaiCuTru,
                l.tuNgay,
                l.denNgay,
                l.ghiChu
            FROM LichSuCuTru l
            LEFT JOIN HoKhau hk ON hk.id = l.id_HK
            WHERE l.id_NK = @idNK
              AND l.loaiCuTru = N'Tạm trú'
            ORDER BY l.tuNgay DESC
            ";

            var dt = knn.ExecuteQuery(
                query,
                new SqlParameter[]
                {
            new SqlParameter("@idNK", idNK)
                }
            );

            dataGridView_TamTru.DataSource = dt;

            dataGridView_TamTru.Columns["loaiCuTru"].HeaderText = "Loại";
            dataGridView_TamTru.Columns["tuNgay"].HeaderText = "Từ ngày";
            dataGridView_TamTru.Columns["denNgay"].HeaderText = "Đến ngày";
            dataGridView_TamTru.Columns["maHoKhau"].HeaderText = "Mã hộ khẩu";
            dataGridView_TamTru.Columns["ghiChu"].HeaderText = "Ghi chú";
            dataGridView_TamTru.Columns["id"].Visible = false;
        }
        private void dataGridView_NhanKhau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView_NhanKhau.Rows[e.RowIndex];

            selectedNhanKhauId = Convert.ToInt32(row.Cells["id"].Value);

            textBox_HoTen.Text = row.Cells["hoTen"].Value.ToString();
            textBox_SoCCCD.Text = row.Cells["soCCCD"].Value.ToString();

            LoadTamTruByNhanKhau(selectedNhanKhauId);
        }
        private void dataGridView_TamTru_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView_TamTru.Rows[e.RowIndex];

            selectedTamTruId = Convert.ToInt32(row.Cells["id"].Value);

            dateTimePicker_Tu.Value = Convert.ToDateTime(row.Cells["tuNgay"].Value);

            textBox_MaHoKhau.Text = row.Cells["maHoKhau"].Value.ToString();
            textBox_GhiChu.Text = row.Cells["ghiChu"].Value.ToString();
            if (row.Cells["denNgay"].Value != DBNull.Value)
                dateTimePicker_Den.Value = Convert.ToDateTime(row.Cells["denNgay"].Value);
            else
                dateTimePicker_Den.Checked = false;

            MessageBox.Show("Đã chọn tạm trú cần sửa");
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. check chọn record
                if (selectedTamTruId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn tạm trú cần sửa");
                    return;
                }

                // 2. validate ngày
                DateTime from = dateTimePicker_Tu.Value.Date;
                DateTime to = dateTimePicker_Den.Value.Date;

                if (dateTimePicker_Den.Checked && to < from)
                {
                    MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu");
                    return;
                }

                // 3. update
                string query = @"
                UPDATE LichSuCuTru
                SET 
                    tuNgay = @tuNgay,
                    denNgay = @denNgay,
                    ghiChu = @ghiChu
                WHERE id = @id
                  AND loaiCuTru = N'Tạm trú'
                ";

                var parameters = new SqlParameter[]
                {
            new SqlParameter("@id", selectedTamTruId),
            new SqlParameter("@tuNgay", from),
            new SqlParameter("@denNgay", (object)dateTimePicker_Den.Value ?? DBNull.Value),
            new SqlParameter("@ghiChu", (object)textBox_GhiChu.Text ?? DBNull.Value)
                };

                knn.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Cập nhật tạm trú thành công!");

                // reload lại grid
                LoadTamTruByNhanKhau(selectedNhanKhauId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView_TamTru_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void SuaTamTru_Load(object sender, EventArgs e)
        {

        }
    }

}
