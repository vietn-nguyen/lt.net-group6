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
    partial class XoaTamTru
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
            button_Thoat = new Button();
            label10 = new Label();
            label9 = new Label();
            dataGridView_NhanKhau = new DataGridView();
            dataGridView_TamTru = new DataGridView();
            button_Xoa = new Button();
            label7 = new Label();
            textBox_TimKiemTamTru = new TextBox();
            textBox_GhiChu = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            textBox_MaHoKhau = new TextBox();
            textBox_SoCCCD = new TextBox();
            textBox_HoTen = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhanKhau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TamTru).BeginInit();
            SuspendLayout();
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(234, 323);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 76;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(918, 150);
            label10.Name = "label10";
            label10.Size = new Size(129, 20);
            label10.TabIndex = 75;
            label10.Text = "Danh sách tạm trú";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(534, 150);
            label9.Name = "label9";
            label9.Size = new Size(148, 20);
            label9.TabIndex = 74;
            label9.Text = "Danh sách nhân khẩu";
            // 
            // dataGridView_NhanKhau
            // 
            dataGridView_NhanKhau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_NhanKhau.Location = new Point(534, 180);
            dataGridView_NhanKhau.Name = "dataGridView_NhanKhau";
            dataGridView_NhanKhau.RowHeadersWidth = 51;
            dataGridView_NhanKhau.Size = new Size(338, 188);
            dataGridView_NhanKhau.TabIndex = 73;
            dataGridView_NhanKhau.CellDoubleClick += dataGridView_NhanKhau_CellDoubleClick;
            // 
            // dataGridView_TamTru
            // 
            dataGridView_TamTru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TamTru.Location = new Point(918, 180);
            dataGridView_TamTru.Name = "dataGridView_TamTru";
            dataGridView_TamTru.RowHeadersWidth = 51;
            dataGridView_TamTru.Size = new Size(338, 188);
            dataGridView_TamTru.TabIndex = 72;
            dataGridView_TamTru.CellDoubleClick += dataGridView_TamTru_CellDoubleClick;
            // 
            // button_Xoa
            // 
            button_Xoa.Location = new Point(80, 323);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(94, 29);
            button_Xoa.TabIndex = 71;
            button_Xoa.Text = "Xóa";
            button_Xoa.UseVisualStyleBackColor = true;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(534, 103);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 70;
            label7.Text = "Tìm kiếm";
            // 
            // textBox_TimKiemTamTru
            // 
            textBox_TimKiemTamTru.Location = new Point(610, 100);
            textBox_TimKiemTamTru.Name = "textBox_TimKiemTamTru";
            //textBox_TimKiemTamTru.PlaceholderText = "Nhập họ tên hoặc CCCD";
            textBox_TimKiemTamTru.Size = new Size(262, 27);
            textBox_TimKiemTamTru.TabIndex = 69;
            textBox_TimKiemTamTru.TextChanged += textBox_TimKiemTamTru_TextChanged;
            // 
            // textBox_GhiChu
            // 
            textBox_GhiChu.Location = new Point(203, 251);
            textBox_GhiChu.Name = "textBox_GhiChu";
            textBox_GhiChu.ReadOnly = true;
            textBox_GhiChu.Size = new Size(125, 27);
            textBox_GhiChu.TabIndex = 68;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 254);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 67;
            label5.Text = "Ghi chú";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-190, 393);
            label6.Name = "label6";
            label6.Size = new Size(26, 20);
            label6.TabIndex = 64;
            label6.Text = "Từ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(77, 205);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 62;
            label4.Text = "Mã hộ khẩu";
            // 
            // textBox_MaHoKhau
            // 
            textBox_MaHoKhau.Location = new Point(203, 202);
            textBox_MaHoKhau.Name = "textBox_MaHoKhau";
            textBox_MaHoKhau.ReadOnly = true;
            textBox_MaHoKhau.Size = new Size(125, 27);
            textBox_MaHoKhau.TabIndex = 61;
            // 
            // textBox_SoCCCD
            // 
            textBox_SoCCCD.Location = new Point(203, 150);
            textBox_SoCCCD.Name = "textBox_SoCCCD";
            textBox_SoCCCD.ReadOnly = true;
            textBox_SoCCCD.Size = new Size(125, 27);
            textBox_SoCCCD.TabIndex = 60;
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Location = new Point(203, 103);
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.ReadOnly = true;
            textBox_HoTen.Size = new Size(125, 27);
            textBox_HoTen.TabIndex = 59;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 157);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 58;
            label3.Text = "Số CCCD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 107);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 57;
            label2.Text = "Họ tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(246, -68);
            label1.Name = "label1";
            label1.Size = new Size(160, 38);
            label1.TabIndex = 56;
            label1.Text = "Sửa tạm trú";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(534, 30);
            label8.Name = "label8";
            label8.Size = new Size(162, 38);
            label8.TabIndex = 77;
            label8.Text = "Xóa tạm trú";
            // 
            // XoaTamTru
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 631);
            Controls.Add(label8);
            Controls.Add(button_Thoat);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(dataGridView_NhanKhau);
            Controls.Add(dataGridView_TamTru);
            Controls.Add(button_Xoa);
            Controls.Add(label7);
            Controls.Add(textBox_TimKiemTamTru);
            Controls.Add(textBox_GhiChu);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBox_MaHoKhau);
            Controls.Add(textBox_SoCCCD);
            Controls.Add(textBox_HoTen);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "XoaTamTru";
            Text = "XoaTamTru";
            Load += XoaTamTru_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhanKhau).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TamTru).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Thoat;
        private Label label10;
        private Label label9;
        private DataGridView dataGridView_NhanKhau;
        private DataGridView dataGridView_TamTru;
        private Button button_Xoa;
        private Label label7;
        private TextBox textBox_TimKiemTamTru;
        private TextBox textBox_GhiChu;
        private Label label5;
        private Label label6;
        private Label label4;
        private TextBox textBox_MaHoKhau;
        private TextBox textBox_SoCCCD;
        private TextBox textBox_HoTen;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label8;
    }
}