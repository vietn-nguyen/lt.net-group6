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
    partial class SuaTamTru
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_HoTen = new System.Windows.Forms.TextBox();
            this.textBox_SoCCCD = new System.Windows.Forms.TextBox();
            this.textBox_MaHoKhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_Den = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_Tu = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_GhiChu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_TimKiemTamTru = new System.Windows.Forms.TextBox();
            this.button_Sua = new System.Windows.Forms.Button();
            this.dataGridView_TamTru = new System.Windows.Forms.DataGridView();
            this.dataGridView_NhanKhau = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TamTru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanKhau)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(758, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sửa tạm trú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số CCCD";
            // 
            // textBox_HoTen
            // 
            this.textBox_HoTen.Location = new System.Drawing.Point(296, 198);
            this.textBox_HoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_HoTen.Name = "textBox_HoTen";
            this.textBox_HoTen.ReadOnly = true;
            this.textBox_HoTen.Size = new System.Drawing.Size(186, 31);
            this.textBox_HoTen.TabIndex = 3;
            // 
            // textBox_SoCCCD
            // 
            this.textBox_SoCCCD.Location = new System.Drawing.Point(296, 256);
            this.textBox_SoCCCD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_SoCCCD.Name = "textBox_SoCCCD";
            this.textBox_SoCCCD.ReadOnly = true;
            this.textBox_SoCCCD.Size = new System.Drawing.Size(186, 31);
            this.textBox_SoCCCD.TabIndex = 4;
            // 
            // textBox_MaHoKhau
            // 
            this.textBox_MaHoKhau.Location = new System.Drawing.Point(296, 321);
            this.textBox_MaHoKhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_MaHoKhau.Name = "textBox_MaHoKhau";
            this.textBox_MaHoKhau.ReadOnly = true;
            this.textBox_MaHoKhau.Size = new System.Drawing.Size(186, 31);
            this.textBox_MaHoKhau.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 325);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã hộ khẩu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(720, 654);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 25);
            this.label8.TabIndex = 44;
            this.label8.Text = "Đến";
            // 
            // dateTimePicker_Den
            // 
            this.dateTimePicker_Den.Location = new System.Drawing.Point(852, 648);
            this.dateTimePicker_Den.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker_Den.Name = "dateTimePicker_Den";
            this.dateTimePicker_Den.ShowCheckBox = true;
            this.dateTimePicker_Den.Size = new System.Drawing.Size(373, 31);
            this.dateTimePicker_Den.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 648);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 25);
            this.label6.TabIndex = 42;
            this.label6.Text = "Từ";
            // 
            // dateTimePicker_Tu
            // 
            this.dateTimePicker_Tu.Location = new System.Drawing.Point(219, 648);
            this.dateTimePicker_Tu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            this.dateTimePicker_Tu.ShowCheckBox = true;
            this.dateTimePicker_Tu.Size = new System.Drawing.Size(373, 31);
            this.dateTimePicker_Tu.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 386);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 45;
            this.label5.Text = "Ghi chú";
            // 
            // textBox_GhiChu
            // 
            this.textBox_GhiChu.Location = new System.Drawing.Point(296, 382);
            this.textBox_GhiChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_GhiChu.Name = "textBox_GhiChu";
            this.textBox_GhiChu.Size = new System.Drawing.Size(186, 31);
            this.textBox_GhiChu.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(792, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Tìm kiếm";
            // 
            // textBox_TimKiemTamTru
            // 
            this.textBox_TimKiemTamTru.Location = new System.Drawing.Point(906, 194);
            this.textBox_TimKiemTamTru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TimKiemTamTru.Name = "textBox_TimKiemTamTru";
            this.textBox_TimKiemTamTru.Size = new System.Drawing.Size(391, 31);
            this.textBox_TimKiemTamTru.TabIndex = 47;
            // 
            // button_Sua
            // 
            this.button_Sua.Location = new System.Drawing.Point(111, 769);
            this.button_Sua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Sua.Name = "button_Sua";
            this.button_Sua.Size = new System.Drawing.Size(141, 36);
            this.button_Sua.TabIndex = 50;
            this.button_Sua.Text = "Sửa";
            this.button_Sua.UseVisualStyleBackColor = true;
            // 
            // dataGridView_TamTru
            // 
            this.dataGridView_TamTru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TamTru.Location = new System.Drawing.Point(1368, 294);
            this.dataGridView_TamTru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_TamTru.Name = "dataGridView_TamTru";
            this.dataGridView_TamTru.RowHeadersWidth = 51;
            this.dataGridView_TamTru.Size = new System.Drawing.Size(507, 235);
            this.dataGridView_TamTru.TabIndex = 51;
            // 
            // dataGridView_NhanKhau
            // 
            this.dataGridView_NhanKhau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NhanKhau.Location = new System.Drawing.Point(792, 294);
            this.dataGridView_NhanKhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_NhanKhau.Name = "dataGridView_NhanKhau";
            this.dataGridView_NhanKhau.RowHeadersWidth = 51;
            this.dataGridView_NhanKhau.Size = new System.Drawing.Size(507, 235);
            this.dataGridView_NhanKhau.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(792, 256);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 25);
            this.label9.TabIndex = 53;
            this.label9.Text = "Danh sách nhân khẩu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1368, 256);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 25);
            this.label10.TabIndex = 54;
            this.label10.Text = "Danh sách tạm trú";
            // 
            // button_Thoat
            // 
            this.button_Thoat.Location = new System.Drawing.Point(342, 769);
            this.button_Thoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Thoat.Name = "button_Thoat";
            this.button_Thoat.Size = new System.Drawing.Size(141, 36);
            this.button_Thoat.TabIndex = 55;
            this.button_Thoat.Text = "Thoát";
            this.button_Thoat.UseVisualStyleBackColor = true;
            // 
            // SuaTamTru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 936);
            this.Controls.Add(this.button_Thoat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView_NhanKhau);
            this.Controls.Add(this.dataGridView_TamTru);
            this.Controls.Add(this.button_Sua);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_TimKiemTamTru);
            this.Controls.Add(this.textBox_GhiChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker_Den);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_Tu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_MaHoKhau);
            this.Controls.Add(this.textBox_SoCCCD);
            this.Controls.Add(this.textBox_HoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SuaTamTru";
            this.Text = "SuaTamTru";
            this.Load += new System.EventHandler(this.SuaTamTru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TamTru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanKhau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_HoTen;
        private TextBox textBox_SoCCCD;
        private TextBox textBox_MaHoKhau;
        private Label label4;
        private Label label8;
        private DateTimePicker dateTimePicker_Den;
        private Label label6;
        private DateTimePicker dateTimePicker_Tu;
        private Label label5;
        private TextBox textBox_GhiChu;
        private ListView listView_TamTru;
        private Label label7;
        private TextBox textBox_TimKiemTamTru;
        private Button button_Sua;
        private DataGridView dataGridView_TamTru;
        private DataGridView dataGridView_NhanKhau;
        private Label label9;
        private Label label10;
        private Button button_Thoat;
    }
}