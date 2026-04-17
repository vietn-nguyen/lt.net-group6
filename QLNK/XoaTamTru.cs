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
    public partial class XoaTamTru : Form
    {
        KETNOI_CSDL knn = new KETNOI_CSDL();
        private System.Windows.Forms.Timer searchTimer;
        private int selectedNhanKhauId = -1;
        private int selectedTamTruId = -1;
        public XoaTamTru()
        {
            InitializeComponent();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += searchTimer_Tick;
        }

        private void XoaTamTru_Load(object sender, EventArgs e)
        {

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



            textBox_MaHoKhau.Text = row.Cells["maHoKhau"].Value.ToString();
            textBox_GhiChu.Text = row.Cells["ghiChu"].Value.ToString();

            MessageBox.Show("Đã chọn tạm trú cần xóa");
        }

       

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. check đã chọn record chưa
                if (selectedTamTruId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn tạm trú cần xóa");
                    return;
                }

                var confirm = MessageBox.Show(
                    "Bạn có chắc muốn xóa (kết thúc) tạm trú này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes) return;

                // 2. update kiểu "soft close"
                string query = @"
                UPDATE LichSuCuTru
                SET denNgay = GETDATE(),
                    ghiChu = ISNULL(ghiChu,'') + N' | Đã kết thúc tạm trú'
                WHERE id = @id
                  AND loaiCuTru = N'Tạm trú'
                  AND denNgay IS NULL
                ";

                var parameters = new SqlParameter[]
                {
            new SqlParameter("@id", selectedTamTruId)
                };

                knn.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Đã kết thúc tạm trú!");

                // 3. reload lại danh sách
                LoadTamTruByNhanKhau(selectedNhanKhauId);

                selectedTamTruId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
