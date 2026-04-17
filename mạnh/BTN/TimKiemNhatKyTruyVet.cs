using Microsoft.Data.SqlClient;
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
    public partial class TimKiemNhatKyTruyVet : Form
    {
        Database db = new Database();
        public TimKiemNhatKyTruyVet()
        {
            InitializeComponent();
        }
        private void LoadTenBang()
        {
            string query = @"
            SELECT DISTINCT tableName 
            FROM AuditLog
            ";
            var dt = db.ExecuteQuery(query);
            comboBox_TenBang.DataSource = dt;
            comboBox_TenBang.DisplayMember = "tableName"; // text hiển thị
            comboBox_TenBang.ValueMember = "tableName";      // giá trị thật
            comboBox_TenBang.SelectedIndex = -1;
        }
        private void LoadHanhDong()
        {
            string query = @"
            SELECT DISTINCT action FROM AuditLog";
            var dt = db.ExecuteQuery(query);
            comboBox_HanhDong.DataSource = dt;
            comboBox_HanhDong.DisplayMember = "action";
            comboBox_HanhDong.ValueMember = "action";
            comboBox_HanhDong.SelectedIndex = -1;
        }
        private void LoadAuditLog()
        {
            string query = @"
            SELECT 
                id,
                tableName,
                action,
                recordId,
                oldData,
                newData,
                userId,
                createdAt
            FROM AuditLog
            WHERE 1=1
            ";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // 1. filter table
            if (!string.IsNullOrWhiteSpace(comboBox_TenBang.Text))
            {
                query += " AND tableName = @table";
                parameters.Add(new SqlParameter("@table", comboBox_TenBang.Text));
            }

            // 2. filter action
            if (!string.IsNullOrWhiteSpace(comboBox_HanhDong.Text))
            {
                query += " AND action = @action";
                parameters.Add(new SqlParameter("@action", comboBox_HanhDong.Text));
            }

            // 3. filter recordId
            if (!string.IsNullOrWhiteSpace(textBox_ID_BanGhi.Text))
            {
                query += " AND recordId = @recordId";
                parameters.Add(new SqlParameter("@recordId", textBox_ID_BanGhi.Text));
            }

            // 4. filter userId
            if (!string.IsNullOrWhiteSpace(textBox_ID_NguoiDung.Text))
            {
                query += " AND userId = @userId";
                parameters.Add(new SqlParameter("@userId", textBox_ID_NguoiDung.Text));
            }

            // 5. filter thời gian
            if (dateTimePicker_Tu.Checked && dateTimePicker_Den.Checked)
            {
                query += " AND createdAt BETWEEN @from AND @to";
                parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value));
                parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value));
            }
            else if (dateTimePicker_Tu.Checked)
            {
                query += " AND createdAt >= @from";
                parameters.Add(new SqlParameter("@from", dateTimePicker_Tu.Value));
            }
            else if (dateTimePicker_Den.Checked)
            {
                query += " AND createdAt <= @to";
                parameters.Add(new SqlParameter("@to", dateTimePicker_Den.Value));
            }

            query += " ORDER BY createdAt DESC";

            dataGridView_NhatKyTruyVet.DataSource = db.ExecuteQuery(query, parameters.ToArray());
            dataGridView_NhatKyTruyVet.Columns["id"].HeaderText = "ID";
            dataGridView_NhatKyTruyVet.Columns["tableName"].HeaderText = "Tên bảng";
            dataGridView_NhatKyTruyVet.Columns["action"].HeaderText = "Hành động";
            dataGridView_NhatKyTruyVet.Columns["recordId"].HeaderText = "ID bản ghi";
            dataGridView_NhatKyTruyVet.Columns["oldData"].HeaderText = "Dữ liệu cũ";
            dataGridView_NhatKyTruyVet.Columns["newData"].HeaderText = "Dữ liệu mới";
            dataGridView_NhatKyTruyVet.Columns["userId"].HeaderText = "ID Người thao tác";
            dataGridView_NhatKyTruyVet.Columns["createdAt"].HeaderText = "Thời gian";
        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            LoadAuditLog();
        }

        private void TimKiemNhatKyTruyVet_Load(object sender, EventArgs e)
        {
            LoadTenBang();
            LoadHanhDong();
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

        private void button_DatLai_Click(object sender, EventArgs e)
        {
            // 1. Reset ComboBox
            comboBox_TenBang.SelectedIndex = -1;
            comboBox_HanhDong.SelectedIndex = -1;

            // 2. Reset TextBox
            textBox_ID_BanGhi.Clear();
            textBox_ID_NguoiDung.Clear();

            // 3. Reset DateTimePicker (QUAN TRỌNG)
            dateTimePicker_Tu.Checked = false;
            dateTimePicker_Den.Checked = false;

            // reset value về mặc định (tránh giữ giá trị cũ)
            dateTimePicker_Tu.Value = DateTime.Now;
            dateTimePicker_Den.Value = DateTime.Now;

            // 4. Reload full data
            LoadAuditLog();
        }
    }
}
