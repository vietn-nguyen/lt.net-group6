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
    partial class TimKiemTamTru
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
            dataGridView_TamTru = new DataGridView();
            button_TimKiem = new Button();
            button_DatLai = new Button();
            button_Thoat = new Button();
            textBox_HoTen = new TextBox();
            textBox_SoCCCD = new TextBox();
            textBox_MaHoKhau = new TextBox();
            dateTimePicker_Tu = new DateTimePicker();
            dateTimePicker_Den = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TamTru).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(278, 64);
            label1.Name = "label1";
            label1.Size = new Size(229, 38);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm tạm trú";
            // 
            // dataGridView_TamTru
            // 
            dataGridView_TamTru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TamTru.Location = new Point(34, 320);
            dataGridView_TamTru.Name = "dataGridView_TamTru";
            dataGridView_TamTru.RowHeadersWidth = 51;
            dataGridView_TamTru.Size = new Size(741, 188);
            dataGridView_TamTru.TabIndex = 1;
            // 
            // button_TimKiem
            // 
            button_TimKiem.Location = new Point(595, 113);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(94, 29);
            button_TimKiem.TabIndex = 2;
            button_TimKiem.Text = "Tìm kiếm";
            button_TimKiem.UseVisualStyleBackColor = true;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // button_DatLai
            // 
            button_DatLai.Location = new Point(595, 158);
            button_DatLai.Name = "button_DatLai";
            button_DatLai.Size = new Size(94, 29);
            button_DatLai.TabIndex = 3;
            button_DatLai.Text = "Đặt lại";
            button_DatLai.UseVisualStyleBackColor = true;
            button_DatLai.Click += button_DatLai_Click;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(595, 203);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 4;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Location = new Point(161, 118);
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.Size = new Size(125, 27);
            textBox_HoTen.TabIndex = 5;
            // 
            // textBox_SoCCCD
            // 
            textBox_SoCCCD.Location = new Point(161, 158);
            textBox_SoCCCD.Name = "textBox_SoCCCD";
            textBox_SoCCCD.Size = new Size(125, 27);
            textBox_SoCCCD.TabIndex = 6;
            // 
            // textBox_MaHoKhau
            // 
            textBox_MaHoKhau.Location = new Point(161, 211);
            textBox_MaHoKhau.Name = "textBox_MaHoKhau";
            textBox_MaHoKhau.Size = new Size(125, 27);
            textBox_MaHoKhau.TabIndex = 7;
            // 
            // dateTimePicker_Tu
            // 
            dateTimePicker_Tu.Location = new Point(125, 262);
            dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            dateTimePicker_Tu.ShowCheckBox = true;
            dateTimePicker_Tu.Size = new Size(250, 27);
            dateTimePicker_Tu.TabIndex = 8;
            // 
            // dateTimePicker_Den
            // 
            dateTimePicker_Den.Location = new Point(513, 263);
            dateTimePicker_Den.Name = "dateTimePicker_Den";
            dateTimePicker_Den.ShowCheckBox = true;
            dateTimePicker_Den.Size = new Size(250, 27);
            dateTimePicker_Den.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 118);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 10;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 158);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 11;
            label3.Text = "Số CCCD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 211);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 12;
            label4.Text = "Mã hộ khẩu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 262);
            label5.Name = "label5";
            label5.Size = new Size(26, 20);
            label5.TabIndex = 13;
            label5.Text = "Từ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(436, 268);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 14;
            label6.Text = "Đến";
            // 
            // TimKiemTamTru
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 532);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dateTimePicker_Den);
            Controls.Add(dateTimePicker_Tu);
            Controls.Add(textBox_MaHoKhau);
            Controls.Add(textBox_SoCCCD);
            Controls.Add(textBox_HoTen);
            Controls.Add(button_Thoat);
            Controls.Add(button_DatLai);
            Controls.Add(button_TimKiem);
            Controls.Add(dataGridView_TamTru);
            Controls.Add(label1);
            Name = "TimKiemTamTru";
            Text = "TimKiemTamTru";
            Load += TimKiemTamTru_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_TamTru).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView_TamTru;
        private Button button_TimKiem;
        private Button button_DatLai;
        private Button button_Thoat;
        private TextBox textBox_HoTen;
        private TextBox textBox_SoCCCD;
        private TextBox textBox_MaHoKhau;
        private DateTimePicker dateTimePicker_Tu;
        private DateTimePicker dateTimePicker_Den;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}