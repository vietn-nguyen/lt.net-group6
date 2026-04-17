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

    public partial class ThemTamTru : Form
    {
        private System.Windows.Forms.Timer searchTimer;
        private int selectedNhanKhauId = -1;
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public ThemTamTru()
        {
            InitializeComponent();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += searchTimer_Tick;
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void ThemTamTru_Load(object sender, EventArgs e)
        {
            listView_NhanKhau.Visible = false;

            listView_NhanKhau.View = View.Details;
            listView_NhanKhau.FullRowSelect = true;
            listView_NhanKhau.GridLines = true;

            listView_NhanKhau.Columns.Clear();
            listView_NhanKhau.Columns.Add("Họ tên", 180);
            listView_NhanKhau.Columns.Add("CCCD", 140);
        }
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            string key = textBox_TimKiemNhanKhau.Text.Trim();

            if (string.IsNullOrEmpty(key))
            {
                listView_NhanKhau.Visible = false;
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

            listView_NhanKhau.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["hoTen"].ToString());
                item.SubItems.Add(row["soCCCD"].ToString());

                // lưu ID vào Tag (quan trọng)
                item.Tag = row["id"];

                listView_NhanKhau.Items.Add(item);
            }

            listView_NhanKhau.Visible = dt.Rows.Count > 0;
        }
        private void listView_NhanKhau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_NhanKhau.SelectedItems.Count == 0) return;

            var item = listView_NhanKhau.SelectedItems[0];

            selectedNhanKhauId = (int)item.Tag;

            textBox_HoTen.Text =
                item.SubItems[0].Text;
            textBox_SoCCCD.Text =
                item.SubItems[1].Text;

            listView_NhanKhau.Visible = false;
        }
        private int getHoKhau(int idNK)
        {
            string query = @"
            SELECT TOP 1 id_HK
            FROM LichSuCuTru
            WHERE id_NK = @idNK
              AND denNgay IS NULL
            ORDER BY tuNgay DESC";
            var dt = knn.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@idNK", idNK) });

            if (dt.Rows.Count == 0) return -1;

            return Convert.ToInt32(dt.Rows[0]["id_HK"]);
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. validate nhân khẩu
                if (selectedNhanKhauId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân khẩu");
                    return;
                }

                // 2. validate ngày
                if (!dateTimePicker_Tu.Checked || !dateTimePicker_Den.Checked)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ ngày từ - đến");
                    return;
                }

                DateTime from = dateTimePicker_Tu.Value.Date;
                DateTime to = dateTimePicker_Den.Value.Date;

                if (to < from)
                {
                    MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu");
                    return;
                }

                // 3. lấy hộ khẩu hiện tại
                int idHK = getHoKhau(selectedNhanKhauId);
                if (idHK == -1)
                {
                    MessageBox.Show("Nhân khẩu chưa có hộ khẩu hiện tại");
                    return;
                }

                // 4. insert tạm trú
                string query = @"
                INSERT INTO LichSuCuTru
                (
                    id_NK,
                    id_HK,
                    loaiCuTru,
                    tuNgay,
                    denNgay,
                    ghiChu
                )
                VALUES
                (
                    @idNK,
                    @idHK,
                    N'Tạm trú',
                    @tuNgay,
                    @denNgay,
                    @ghiChu
                )";

                var parameters = new SqlParameter[]
                {
            new SqlParameter("@idNK", selectedNhanKhauId),
            new SqlParameter("@idHK", idHK),
            new SqlParameter("@tuNgay", from),
            new SqlParameter("@denNgay", to),
            new SqlParameter("@ghiChu", textBox_GhiChu.Text ?? (object)DBNull.Value)
                };

                knn.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Thêm tạm trú thành công!");

                // optional: reset form
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            selectedNhanKhauId = -1;

            textBox_TimKiemNhanKhau.Clear();
            textBox_HoTen.Clear();
            textBox_SoCCCD.Clear();
            textBox_GhiChu.Clear();

            listView_NhanKhau.Visible = false;
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
