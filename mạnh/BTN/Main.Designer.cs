namespace BTN
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridView_HoKhau = new DataGridView();
            button_Them = new Button();
            button_Sua = new Button();
            button_Xoa = new Button();
            button_ThemTamTru = new Button();
            button_SuaTamTru = new Button();
            button_XoaTamTru = new Button();
            button_TimKiemTamTru = new Button();
            button_TimLichSuCuTru = new Button();
            button_TimNhatKyTruyVet = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(242, 52);
            label1.Name = "label1";
            label1.Size = new Size(299, 38);
            label1.TabIndex = 0;
            label1.Text = "Form Quản lý Hộ Khẩu";
            // 
            // dataGridView_HoKhau
            // 
            dataGridView_HoKhau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HoKhau.Location = new Point(50, 153);
            dataGridView_HoKhau.Name = "dataGridView_HoKhau";
            dataGridView_HoKhau.RowHeadersWidth = 51;
            dataGridView_HoKhau.Size = new Size(491, 188);
            dataGridView_HoKhau.TabIndex = 1;
            // 
            // button_Them
            // 
            button_Them.Location = new Point(606, 153);
            button_Them.Name = "button_Them";
            button_Them.Size = new Size(94, 29);
            button_Them.TabIndex = 2;
            button_Them.Text = "Thêm";
            button_Them.UseVisualStyleBackColor = true;
            button_Them.Click += button_Them_Click;
            // 
            // button_Sua
            // 
            button_Sua.Location = new Point(606, 188);
            button_Sua.Name = "button_Sua";
            button_Sua.Size = new Size(94, 29);
            button_Sua.TabIndex = 3;
            button_Sua.Text = "Sửa";
            button_Sua.UseVisualStyleBackColor = true;
            button_Sua.Click += button_Sua_Click;
            // 
            // button_Xoa
            // 
            button_Xoa.Location = new Point(606, 223);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(94, 29);
            button_Xoa.TabIndex = 4;
            button_Xoa.Text = "Xóa";
            button_Xoa.UseVisualStyleBackColor = true;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // button_ThemTamTru
            // 
            button_ThemTamTru.Location = new Point(868, 153);
            button_ThemTamTru.Name = "button_ThemTamTru";
            button_ThemTamTru.Size = new Size(94, 29);
            button_ThemTamTru.TabIndex = 5;
            button_ThemTamTru.Text = "Thêm";
            button_ThemTamTru.UseVisualStyleBackColor = true;
            button_ThemTamTru.Click += button_ThemTamTru_Click;
            // 
            // button_SuaTamTru
            // 
            button_SuaTamTru.Location = new Point(868, 188);
            button_SuaTamTru.Name = "button_SuaTamTru";
            button_SuaTamTru.Size = new Size(94, 29);
            button_SuaTamTru.TabIndex = 6;
            button_SuaTamTru.Text = "Sửa";
            button_SuaTamTru.UseVisualStyleBackColor = true;
            button_SuaTamTru.Click += button_SuaTamTru_Click;
            // 
            // button_XoaTamTru
            // 
            button_XoaTamTru.Location = new Point(868, 223);
            button_XoaTamTru.Name = "button_XoaTamTru";
            button_XoaTamTru.Size = new Size(94, 29);
            button_XoaTamTru.TabIndex = 7;
            button_XoaTamTru.Text = "Xóa";
            button_XoaTamTru.UseVisualStyleBackColor = true;
            button_XoaTamTru.Click += button_XoaTamTru_Click;
            // 
            // button_TimKiemTamTru
            // 
            button_TimKiemTamTru.Location = new Point(868, 267);
            button_TimKiemTamTru.Name = "button_TimKiemTamTru";
            button_TimKiemTamTru.Size = new Size(94, 29);
            button_TimKiemTamTru.TabIndex = 8;
            button_TimKiemTamTru.Text = "Tìm kiếm";
            button_TimKiemTamTru.UseVisualStyleBackColor = true;
            button_TimKiemTamTru.Click += button_TimKiemTamTru_Click;
            // 
            // button_TimLichSuCuTru
            // 
            button_TimLichSuCuTru.Location = new Point(606, 354);
            button_TimLichSuCuTru.Name = "button_TimLichSuCuTru";
            button_TimLichSuCuTru.Size = new Size(155, 29);
            button_TimLichSuCuTru.TabIndex = 9;
            button_TimLichSuCuTru.Text = "Tìm lịch sử cư trú";
            button_TimLichSuCuTru.UseVisualStyleBackColor = true;
            button_TimLichSuCuTru.Click += button_TimKiemLichSuCuTru_Click;
            // 
            // button_TimNhatKyTruyVet
            // 
            button_TimNhatKyTruyVet.Location = new Point(837, 354);
            button_TimNhatKyTruyVet.Name = "button_TimNhatKyTruyVet";
            button_TimNhatKyTruyVet.Size = new Size(159, 29);
            button_TimNhatKyTruyVet.TabIndex = 10;
            button_TimNhatKyTruyVet.Text = "Tìm nhật ký truy vết";
            button_TimNhatKyTruyVet.UseVisualStyleBackColor = true;
            button_TimNhatKyTruyVet.Click += button_TimKiemNhatKyTruyVet_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 546);
            Controls.Add(button_TimNhatKyTruyVet);
            Controls.Add(button_TimLichSuCuTru);
            Controls.Add(button_TimKiemTamTru);
            Controls.Add(button_XoaTamTru);
            Controls.Add(button_SuaTamTru);
            Controls.Add(button_ThemTamTru);
            Controls.Add(button_Xoa);
            Controls.Add(button_Sua);
            Controls.Add(button_Them);
            Controls.Add(dataGridView_HoKhau);
            Controls.Add(label1);
            Name = "Main";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView_HoKhau;
        private Button button_Them;
        private Button button_Sua;
        private Button button_Xoa;
        private Button button_ThemTamTru;
        private Button button_SuaTamTru;
        private Button button_XoaTamTru;
        private Button button_TimKiemTamTru;
        private Button button_TimLichSuCuTru;
        private Button button_TimNhatKyTruyVet;
    }
}
