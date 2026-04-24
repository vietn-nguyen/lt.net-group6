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
    partial class TimKiemNhatKyTruyVet
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
            label2 = new Label();
            label3 = new Label();
            textBox_ID_NguoiDung = new TextBox();
            label4 = new Label();
            dataGridView_NhatKyTruyVet = new DataGridView();
            label8 = new Label();
            dateTimePicker_Den = new DateTimePicker();
            label5 = new Label();
            dateTimePicker_Tu = new DateTimePicker();
            comboBox_TenBang = new ComboBox();
            comboBox_HanhDong = new ComboBox();
            textBox_ID_BanGhi = new TextBox();
            button_TimKiem = new Button();
            button_Thoat = new Button();
            button_DatLai = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhatKyTruyVet).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 103);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên bảng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 152);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 3;
            label2.Text = "Hành động";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 197);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 5;
            label3.Text = "ID Bản ghi";
            // 
            // textBox_ID_NguoiDung
            // 
            textBox_ID_NguoiDung.Location = new Point(165, 242);
            textBox_ID_NguoiDung.Name = "textBox_ID_NguoiDung";
            textBox_ID_NguoiDung.Size = new Size(151, 27);
            textBox_ID_NguoiDung.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 245);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 7;
            label4.Text = "ID Người dùng";
            // 
            // dataGridView_NhatKyTruyVet
            // 
            dataGridView_NhatKyTruyVet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_NhatKyTruyVet.Location = new Point(52, 383);
            dataGridView_NhatKyTruyVet.Name = "dataGridView_NhatKyTruyVet";
            dataGridView_NhatKyTruyVet.RowHeadersWidth = 51;
            dataGridView_NhatKyTruyVet.Size = new Size(881, 188);
            dataGridView_NhatKyTruyVet.TabIndex = 47;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(460, 307);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 46;
            label8.Text = "Đến";
            // 
            // dateTimePicker_Den
            // 
            dateTimePicker_Den.Location = new Point(548, 302);
            dateTimePicker_Den.Name = "dateTimePicker_Den";
            dateTimePicker_Den.ShowCheckBox = true;
            dateTimePicker_Den.Size = new Size(250, 27);
            dateTimePicker_Den.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 302);
            label5.Name = "label5";
            label5.Size = new Size(26, 20);
            label5.TabIndex = 44;
            label5.Text = "Từ";
            // 
            // dateTimePicker_Tu
            // 
            dateTimePicker_Tu.Location = new Point(126, 302);
            dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            dateTimePicker_Tu.ShowCheckBox = true;
            dateTimePicker_Tu.Size = new Size(250, 27);
            dateTimePicker_Tu.TabIndex = 43;
            // 
            // comboBox_TenBang
            // 
            comboBox_TenBang.FormattingEnabled = true;
            comboBox_TenBang.Location = new Point(165, 100);
            comboBox_TenBang.Name = "comboBox_TenBang";
            comboBox_TenBang.Size = new Size(151, 28);
            comboBox_TenBang.TabIndex = 48;
            // 
            // comboBox_HanhDong
            // 
            comboBox_HanhDong.FormattingEnabled = true;
            comboBox_HanhDong.Location = new Point(165, 149);
            comboBox_HanhDong.Name = "comboBox_HanhDong";
            comboBox_HanhDong.Size = new Size(151, 28);
            comboBox_HanhDong.TabIndex = 49;
            // 
            // textBox_ID_BanGhi
            // 
            textBox_ID_BanGhi.Location = new Point(165, 194);
            textBox_ID_BanGhi.Name = "textBox_ID_BanGhi";
            textBox_ID_BanGhi.Size = new Size(151, 27);
            textBox_ID_BanGhi.TabIndex = 50;
            // 
            // button_TimKiem
            // 
            button_TimKiem.Location = new Point(704, 103);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(94, 29);
            button_TimKiem.TabIndex = 51;
            button_TimKiem.Text = "Tìm Kiếm";
            button_TimKiem.UseVisualStyleBackColor = true;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(704, 197);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 52;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // button_DatLai
            // 
            button_DatLai.Location = new Point(704, 152);
            button_DatLai.Name = "button_DatLai";
            button_DatLai.Size = new Size(94, 29);
            button_DatLai.TabIndex = 53;
            button_DatLai.Text = "Đặt lại";
            button_DatLai.UseVisualStyleBackColor = true;
            button_DatLai.Click += button_DatLai_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(310, 25);
            label6.Name = "label6";
            label6.Size = new Size(332, 38);
            label6.TabIndex = 54;
            label6.Text = "Tìm kiếm nhật ký truy vết";
            // 
            // TimKiemNhatKyTruyVet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 605);
            Controls.Add(label6);
            Controls.Add(button_DatLai);
            Controls.Add(button_Thoat);
            Controls.Add(button_TimKiem);
            Controls.Add(textBox_ID_BanGhi);
            Controls.Add(comboBox_HanhDong);
            Controls.Add(comboBox_TenBang);
            Controls.Add(dataGridView_NhatKyTruyVet);
            Controls.Add(label8);
            Controls.Add(dateTimePicker_Den);
            Controls.Add(label5);
            Controls.Add(dateTimePicker_Tu);
            Controls.Add(label4);
            Controls.Add(textBox_ID_NguoiDung);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TimKiemNhatKyTruyVet";
            Text = "TimKiemNhatKyTruyVet";
            Load += TimKiemNhatKyTruyVet_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhatKyTruyVet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBox_HanhDong;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox_ID_NguoiDung;
        private Label label4;
        private DataGridView dataGridView_NhatKyTruyVet;
        private Label label8;
        private DateTimePicker dateTimePicker_Den;
        private Label label5;
        private DateTimePicker dateTimePicker_Tu;
        private ComboBox comboBox_TenBang;
        private ComboBox comboBox_HanhDong;
        private TextBox textBox_ID_BanGhi;
        private Button button_TimKiem;
        private Button button_Thoat;
        private Button button_DatLai;
        private Label label6;
    }
}