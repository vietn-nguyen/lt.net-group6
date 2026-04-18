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
    partial class Search
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
            label1 = new Label();
            label7 = new Label();
            comboBox_Tinh = new ComboBox();
            dataGridView_HoKhau = new DataGridView();
            button_Thoat = new Button();
            button_TimKiem = new Button();
            checkBox_Xoa = new CheckBox();
            label6 = new Label();
            label4 = new Label();
            dateTimePicker_Tu = new DateTimePicker();
            label3 = new Label();
            textBox_DiaChi = new TextBox();
            label2 = new Label();
            comboBox_Xa = new ComboBox();
            label5 = new Label();
            textBox_Ma_HoKhau = new TextBox();
            dateTimePicker_Den = new DateTimePicker();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(354, 9);
            label1.Name = "label1";
            label1.Size = new Size(239, 38);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm thay đổi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(138, 126);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 30;
            label7.Text = "Tỉnh";
            // 
            // comboBox_Tinh
            // 
            comboBox_Tinh.FormattingEnabled = true;
            comboBox_Tinh.Location = new Point(248, 126);
            comboBox_Tinh.Name = "comboBox_Tinh";
            comboBox_Tinh.Size = new Size(151, 28);
            comboBox_Tinh.TabIndex = 29;
            comboBox_Tinh.SelectedIndexChanged += comboBox_Tinh_SelectedIndexChanged;
            // 
            // dataGridView_HoKhau
            // 
            dataGridView_HoKhau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HoKhau.Location = new Point(138, 328);
            dataGridView_HoKhau.Name = "dataGridView_HoKhau";
            dataGridView_HoKhau.RowHeadersWidth = 51;
            dataGridView_HoKhau.Size = new Size(702, 188);
            dataGridView_HoKhau.TabIndex = 28;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(639, 159);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 27;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // button_TimKiem
            // 
            button_TimKiem.Location = new Point(638, 115);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(94, 29);
            button_TimKiem.TabIndex = 26;
            button_TimKiem.Text = "Tìm kiếm";
            button_TimKiem.UseVisualStyleBackColor = true;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // checkBox_Xoa
            // 
            checkBox_Xoa.AutoSize = true;
            checkBox_Xoa.Location = new Point(638, 73);
            checkBox_Xoa.Name = "checkBox_Xoa";
            checkBox_Xoa.Size = new Size(95, 24);
            checkBox_Xoa.TabIndex = 25;
            checkBox_Xoa.Text = "Đã bị xóa";
            checkBox_Xoa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(577, 74);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(138, 282);
            label4.Name = "label4";
            label4.Size = new Size(26, 20);
            label4.TabIndex = 23;
            label4.Text = "Từ";
            // 
            // dateTimePicker_Tu
            // 
            dateTimePicker_Tu.Location = new Point(248, 275);
            dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            dateTimePicker_Tu.ShowCheckBox = true;
            dateTimePicker_Tu.Size = new Size(250, 27);
            dateTimePicker_Tu.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 218);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 21;
            label3.Text = "Địa chi";
            // 
            // textBox_DiaChi
            // 
            textBox_DiaChi.Location = new Point(248, 215);
            textBox_DiaChi.Multiline = true;
            textBox_DiaChi.Name = "textBox_DiaChi";
            textBox_DiaChi.Size = new Size(151, 34);
            textBox_DiaChi.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 173);
            label2.Name = "label2";
            label2.Size = new Size(26, 20);
            label2.TabIndex = 19;
            label2.Text = "Xã";
            // 
            // comboBox_Xa
            // 
            comboBox_Xa.FormattingEnabled = true;
            comboBox_Xa.Location = new Point(248, 170);
            comboBox_Xa.Name = "comboBox_Xa";
            comboBox_Xa.Size = new Size(151, 28);
            comboBox_Xa.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(138, 77);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 17;
            label5.Text = "Mã hộ khẩu";
            // 
            // textBox_Ma_HoKhau
            // 
            textBox_Ma_HoKhau.Location = new Point(248, 74);
            textBox_Ma_HoKhau.Name = "textBox_Ma_HoKhau";
            textBox_Ma_HoKhau.Size = new Size(151, 27);
            textBox_Ma_HoKhau.TabIndex = 16;
            // 
            // dateTimePicker_Den
            // 
            dateTimePicker_Den.Location = new Point(639, 273);
            dateTimePicker_Den.Name = "dateTimePicker_Den";
            dateTimePicker_Den.ShowCheckBox = true;
            dateTimePicker_Den.Size = new Size(250, 27);
            dateTimePicker_Den.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(557, 278);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 32;
            label8.Text = "Đến";
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 528);
            Controls.Add(label8);
            Controls.Add(dateTimePicker_Den);
            Controls.Add(label7);
            Controls.Add(comboBox_Tinh);
            Controls.Add(dataGridView_HoKhau);
            Controls.Add(button_Thoat);
            Controls.Add(button_TimKiem);
            Controls.Add(checkBox_Xoa);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(dateTimePicker_Tu);
            Controls.Add(label3);
            Controls.Add(textBox_DiaChi);
            Controls.Add(label2);
            Controls.Add(comboBox_Xa);
            Controls.Add(label5);
            Controls.Add(textBox_Ma_HoKhau);
            Controls.Add(label1);
            Name = "Search";
            Text = "Search";
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private ComboBox comboBox_Tinh;
        private DataGridView dataGridView_HoKhau;
        private Button button_Thoat;
        private Button button_TimKiem;
        private CheckBox checkBox_Xoa;
        private Label label6;
        private Label label4;
        private DateTimePicker dateTimePicker_Tu;
        private Label label3;
        private TextBox textBox_DiaChi;
        private Label label2;
        private ComboBox comboBox_Xa;
        private Label label5;
        private TextBox textBox_Ma_HoKhau;
        private DateTimePicker dateTimePicker_Den;
        private Label label8;
    }
}