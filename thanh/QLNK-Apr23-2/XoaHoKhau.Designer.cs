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

namespace BTN
{
    partial class XoaHoKhau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new Label();
            comboBox_Tinh = new ComboBox();
            dataGridView_HoKhau = new DataGridView();
            button_Thoat = new Button();
            button_Xoa = new Button();
            checkBox_Xoa = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker_NgayLap = new DateTimePicker();
            label3 = new Label();
            textBox_DiaChi = new TextBox();
            label2 = new Label();
            comboBox_Xa = new ComboBox();
            label1 = new Label();
            textBox_Ma_HoKhau = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(122, 178);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 31;
            label7.Text = "Tỉnh";
            // 
            // comboBox_Tinh
            // 
            comboBox_Tinh.Enabled = false;
            comboBox_Tinh.FormattingEnabled = true;
            comboBox_Tinh.Location = new Point(232, 178);
            comboBox_Tinh.Name = "comboBox_Tinh";
            comboBox_Tinh.Size = new Size(151, 28);
            comboBox_Tinh.TabIndex = 30;
            // 
            // dataGridView_HoKhau
            // 
            dataGridView_HoKhau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HoKhau.Location = new Point(122, 384);
            dataGridView_HoKhau.Name = "dataGridView_HoKhau";
            dataGridView_HoKhau.RowHeadersWidth = 51;
            dataGridView_HoKhau.Size = new Size(729, 188);
            dataGridView_HoKhau.TabIndex = 29;
            dataGridView_HoKhau.CellClick += dataGridView_HoKhau_CellClick;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(623, 211);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 28;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // button_Xoa
            // 
            button_Xoa.Location = new Point(622, 167);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(94, 29);
            button_Xoa.TabIndex = 27;
            button_Xoa.Text = "Xóa";
            button_Xoa.UseVisualStyleBackColor = true;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // checkBox_Xoa
            // 
            checkBox_Xoa.AutoSize = true;
            checkBox_Xoa.Enabled = false;
            checkBox_Xoa.Location = new Point(622, 125);
            checkBox_Xoa.Name = "checkBox_Xoa";
            checkBox_Xoa.Size = new Size(95, 24);
            checkBox_Xoa.TabIndex = 26;
            checkBox_Xoa.Text = "Đã bị xóa";
            checkBox_Xoa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(561, 126);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(361, 58);
            label5.Name = "label5";
            label5.Size = new Size(248, 38);
            label5.TabIndex = 24;
            label5.Text = "Form Sửa Hộ Khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(122, 330);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 23;
            label4.Text = "Ngày Lập";
            // 
            // dateTimePicker_NgayLap
            // 
            dateTimePicker_NgayLap.Enabled = false;
            dateTimePicker_NgayLap.Location = new Point(232, 325);
            dateTimePicker_NgayLap.Name = "dateTimePicker_NgayLap";
            dateTimePicker_NgayLap.Size = new Size(250, 27);
            dateTimePicker_NgayLap.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 270);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 21;
            label3.Text = "Địa chi";
            // 
            // textBox_DiaChi
            // 
            textBox_DiaChi.Location = new Point(232, 267);
            textBox_DiaChi.Multiline = true;
            textBox_DiaChi.Name = "textBox_DiaChi";
            textBox_DiaChi.ReadOnly = true;
            textBox_DiaChi.Size = new Size(151, 34);
            textBox_DiaChi.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 225);
            label2.Name = "label2";
            label2.Size = new Size(26, 20);
            label2.TabIndex = 19;
            label2.Text = "Xã";
            // 
            // comboBox_Xa
            // 
            comboBox_Xa.Enabled = false;
            comboBox_Xa.FormattingEnabled = true;
            comboBox_Xa.Location = new Point(232, 225);
            comboBox_Xa.Name = "comboBox_Xa";
            comboBox_Xa.Size = new Size(151, 28);
            comboBox_Xa.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 129);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 17;
            label1.Text = "Mã hộ khẩu";
            // 
            // textBox_Ma_HoKhau
            // 
            textBox_Ma_HoKhau.Location = new Point(232, 126);
            textBox_Ma_HoKhau.Name = "textBox_Ma_HoKhau";
            textBox_Ma_HoKhau.ReadOnly = true;
            textBox_Ma_HoKhau.Size = new Size(151, 27);
            textBox_Ma_HoKhau.TabIndex = 16;
            // 
            // Delete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 624);
            Controls.Add(label7);
            Controls.Add(comboBox_Tinh);
            Controls.Add(dataGridView_HoKhau);
            Controls.Add(button_Thoat);
            Controls.Add(button_Xoa);
            Controls.Add(checkBox_Xoa);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePicker_NgayLap);
            Controls.Add(label3);
            Controls.Add(textBox_DiaChi);
            Controls.Add(label2);
            Controls.Add(comboBox_Xa);
            Controls.Add(label1);
            Controls.Add(textBox_Ma_HoKhau);
            Name = "Delete";
            Text = "Delete";
            Load += Delete_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private ComboBox comboBox_Tinh;
        private DataGridView dataGridView_HoKhau;
        private Button button_Thoat;
        private Button button_Xoa;
        private CheckBox checkBox_Xoa;
        private Label label6;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePicker_NgayLap;
        private Label label3;
        private TextBox textBox_DiaChi;
        private Label label2;
        private ComboBox comboBox_Xa;
        private Label label1;
        private TextBox textBox_Ma_HoKhau;
    }
}