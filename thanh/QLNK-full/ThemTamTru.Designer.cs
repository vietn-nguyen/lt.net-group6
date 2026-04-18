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
    partial class ThemTamTru
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
            label3 = new Label();
            textBox_HoTen = new TextBox();
            textBox_SoCCCD = new TextBox();
            textBox_TimKiemNhanKhau = new TextBox();
            label4 = new Label();
            label5 = new Label();
            listView_NhanKhau = new ListView();
            label8 = new Label();
            dateTimePicker_Den = new DateTimePicker();
            label6 = new Label();
            dateTimePicker_Tu = new DateTimePicker();
            textBox_GhiChu = new TextBox();
            label7 = new Label();
            button_Them = new Button();
            button_Thoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(330, 35);
            label1.Name = "label1";
            label1.Size = new Size(185, 38);
            label1.TabIndex = 0;
            label1.Text = "Thêm tạm trú";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 111);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 3;
            label3.Text = "Họ Tên";
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Location = new Point(170, 111);
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.Size = new Size(151, 27);
            textBox_HoTen.TabIndex = 4;
            // 
            // textBox_SoCCCD
            // 
            textBox_SoCCCD.Location = new Point(170, 156);
            textBox_SoCCCD.Name = "textBox_SoCCCD";
            textBox_SoCCCD.Size = new Size(151, 27);
            textBox_SoCCCD.TabIndex = 5;
            // 
            // textBox_TimKiemNhanKhau
            // 
            textBox_TimKiemNhanKhau.Location = new Point(560, 108);
            textBox_TimKiemNhanKhau.Name = "textBox_TimKiemNhanKhau";
            textBox_TimKiemNhanKhau.Size = new Size(151, 27);
            textBox_TimKiemNhanKhau.TabIndex = 6;
            textBox_TimKiemNhanKhau.TextChanged += textBox_TimKiem_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 156);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 7;
            label4.Text = "Số CCCD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(484, 111);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 8;
            label5.Text = "Tìm kiếm";
            // 
            // listView_NhanKhau
            // 
            listView_NhanKhau.Location = new Point(484, 158);
            listView_NhanKhau.Name = "listView_NhanKhau";
            listView_NhanKhau.Size = new Size(338, 159);
            listView_NhanKhau.TabIndex = 10;
            listView_NhanKhau.UseCompatibleStateImageBehavior = false;
            listView_NhanKhau.SelectedIndexChanged += listView_NhanKhau_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(488, 353);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 40;
            label8.Text = "Đến";
            // 
            // dateTimePicker_Den
            // 
            dateTimePicker_Den.Location = new Point(576, 348);
            dateTimePicker_Den.Name = "dateTimePicker_Den";
            dateTimePicker_Den.ShowCheckBox = true;
            dateTimePicker_Den.Size = new Size(250, 27);
            dateTimePicker_Den.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(77, 348);
            label6.Name = "label6";
            label6.Size = new Size(26, 20);
            label6.TabIndex = 38;
            label6.Text = "Từ";
            // 
            // dateTimePicker_Tu
            // 
            dateTimePicker_Tu.Location = new Point(154, 348);
            dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            dateTimePicker_Tu.ShowCheckBox = true;
            dateTimePicker_Tu.Size = new Size(250, 27);
            dateTimePicker_Tu.TabIndex = 37;
            // 
            // textBox_GhiChu
            // 
            textBox_GhiChu.Location = new Point(170, 205);
            textBox_GhiChu.Name = "textBox_GhiChu";
            //textBox_GhiChu.PlaceholderText = "Ghi chú";
            textBox_GhiChu.Size = new Size(151, 27);
            textBox_GhiChu.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(69, 208);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 42;
            label7.Text = "Ghi chú";
            // 
            // button_Them
            // 
            button_Them.Location = new Point(77, 409);
            button_Them.Name = "button_Them";
            button_Them.Size = new Size(94, 29);
            button_Them.TabIndex = 43;
            button_Them.Text = "Thêm";
            button_Them.UseVisualStyleBackColor = true;
            button_Them.Click += button_Them_Click;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(216, 409);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 44;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // ThemTamTru
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 481);
            Controls.Add(button_Thoat);
            Controls.Add(button_Them);
            Controls.Add(label7);
            Controls.Add(textBox_GhiChu);
            Controls.Add(label8);
            Controls.Add(dateTimePicker_Den);
            Controls.Add(label6);
            Controls.Add(dateTimePicker_Tu);
            Controls.Add(listView_NhanKhau);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox_TimKiemNhanKhau);
            Controls.Add(textBox_SoCCCD);
            Controls.Add(textBox_HoTen);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "ThemTamTru";
            Text = "ThemTamTru";
            Load += ThemTamTru_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox textBox_HoTen;
        private TextBox textBox_SoCCCD;
        private TextBox textBox_TimKiemNhanKhau;
        private Label label4;
        private Label label5;
        private ListView listView_NhanKhau;
        private Label label8;
        private DateTimePicker dateTimePicker_Den;
        private Label label6;
        private DateTimePicker dateTimePicker_Tu;
        private TextBox textBox_GhiChu;
        private Label label7;
        private Button button_Them;
        private Button button_Thoat;
    }
}