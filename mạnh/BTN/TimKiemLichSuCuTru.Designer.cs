namespace BTN
{
    partial class TimKiemLichSuCuTru: Form
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
            textBox_HoTen = new TextBox();
            textBox_SoCCCD = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            dateTimePicker_Den = new DateTimePicker();
            label4 = new Label();
            dateTimePicker_Tu = new DateTimePicker();
            label3 = new Label();
            textBox_MaHoKhau = new TextBox();
            comboBox_LoaiCuTru = new ComboBox();
            label5 = new Label();
            button_TimKiem = new Button();
            dataGridView_LichSuCuTru = new DataGridView();
            button_Thoat = new Button();
            label7 = new Label();
            comboBox_Tinh = new ComboBox();
            label6 = new Label();
            comboBox_Xa = new ComboBox();
            button_DatLai = new Button();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_LichSuCuTru).BeginInit();
            SuspendLayout();
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Location = new Point(190, 102);
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.Size = new Size(125, 27);
            textBox_HoTen.TabIndex = 0;
            // 
            // textBox_SoCCCD
            // 
            textBox_SoCCCD.Location = new Point(190, 143);
            textBox_SoCCCD.Name = "textBox_SoCCCD";
            textBox_SoCCCD.Size = new Size(125, 27);
            textBox_SoCCCD.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 105);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 3;
            label1.Text = "Họ Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 146);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 4;
            label2.Text = "Số CCCD";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(464, 255);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 36;
            label8.Text = "Đến";
            // 
            // dateTimePicker_Den
            // 
            dateTimePicker_Den.Location = new Point(552, 250);
            dateTimePicker_Den.Name = "dateTimePicker_Den";
            dateTimePicker_Den.ShowCheckBox = true;
            dateTimePicker_Den.Size = new Size(250, 27);
            dateTimePicker_Den.TabIndex = 35;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 250);
            label4.Name = "label4";
            label4.Size = new Size(26, 20);
            label4.TabIndex = 34;
            label4.Text = "Từ";
            // 
            // dateTimePicker_Tu
            // 
            dateTimePicker_Tu.Location = new Point(130, 250);
            dateTimePicker_Tu.Name = "dateTimePicker_Tu";
            dateTimePicker_Tu.ShowCheckBox = true;
            dateTimePicker_Tu.Size = new Size(250, 27);
            dateTimePicker_Tu.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 188);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 37;
            label3.Text = "Mã hộ khẩu";
            // 
            // textBox_MaHoKhau
            // 
            textBox_MaHoKhau.Location = new Point(190, 185);
            textBox_MaHoKhau.Name = "textBox_MaHoKhau";
            textBox_MaHoKhau.Size = new Size(125, 27);
            textBox_MaHoKhau.TabIndex = 38;
            // 
            // comboBox_LoaiCuTru
            // 
            comboBox_LoaiCuTru.FormattingEnabled = true;
            comboBox_LoaiCuTru.Location = new Point(576, 97);
            comboBox_LoaiCuTru.Name = "comboBox_LoaiCuTru";
            comboBox_LoaiCuTru.Size = new Size(151, 28);
            comboBox_LoaiCuTru.TabIndex = 39;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(464, 105);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 40;
            label5.Text = "Loại cư trú";
            // 
            // button_TimKiem
            // 
            button_TimKiem.Location = new Point(813, 97);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(94, 29);
            button_TimKiem.TabIndex = 41;
            button_TimKiem.Text = "Tìm kiếm";
            button_TimKiem.UseVisualStyleBackColor = true;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // dataGridView_LichSuCuTru
            // 
            dataGridView_LichSuCuTru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_LichSuCuTru.Location = new Point(56, 331);
            dataGridView_LichSuCuTru.Name = "dataGridView_LichSuCuTru";
            dataGridView_LichSuCuTru.RowHeadersWidth = 51;
            dataGridView_LichSuCuTru.Size = new Size(851, 188);
            dataGridView_LichSuCuTru.TabIndex = 42;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(813, 191);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 43;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(466, 147);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 47;
            label7.Text = "Tỉnh";
            // 
            // comboBox_Tinh
            // 
            comboBox_Tinh.FormattingEnabled = true;
            comboBox_Tinh.Location = new Point(576, 147);
            comboBox_Tinh.Name = "comboBox_Tinh";
            comboBox_Tinh.Size = new Size(151, 28);
            comboBox_Tinh.TabIndex = 46;
            comboBox_Tinh.SelectedIndexChanged += comboBox_Tinh_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(466, 194);
            label6.Name = "label6";
            label6.Size = new Size(26, 20);
            label6.TabIndex = 45;
            label6.Text = "Xã";
            // 
            // comboBox_Xa
            // 
            comboBox_Xa.FormattingEnabled = true;
            comboBox_Xa.Location = new Point(576, 191);
            comboBox_Xa.Name = "comboBox_Xa";
            comboBox_Xa.Size = new Size(151, 28);
            comboBox_Xa.TabIndex = 44;
            // 
            // button_DatLai
            // 
            button_DatLai.Location = new Point(813, 146);
            button_DatLai.Name = "button_DatLai";
            button_DatLai.Size = new Size(94, 29);
            button_DatLai.TabIndex = 48;
            button_DatLai.Text = "Đặt lại";
            button_DatLai.UseVisualStyleBackColor = true;
            button_DatLai.Click += button_DatLai_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(328, 24);
            label9.Name = "label9";
            label9.Size = new Size(298, 38);
            label9.TabIndex = 49;
            label9.Text = "Tìm kiếm lịch sử cư trú";
            // 
            // TimKiemLichSuCuTru
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 543);
            Controls.Add(label9);
            Controls.Add(button_DatLai);
            Controls.Add(label7);
            Controls.Add(comboBox_Tinh);
            Controls.Add(label6);
            Controls.Add(comboBox_Xa);
            Controls.Add(button_Thoat);
            Controls.Add(dataGridView_LichSuCuTru);
            Controls.Add(button_TimKiem);
            Controls.Add(label5);
            Controls.Add(comboBox_LoaiCuTru);
            Controls.Add(textBox_MaHoKhau);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(dateTimePicker_Den);
            Controls.Add(label4);
            Controls.Add(dateTimePicker_Tu);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_SoCCCD);
            Controls.Add(textBox_HoTen);
            Name = "TimKiemLichSuCuTru";
            Text = "TimKiemLichSuCuTru";
            Load += TimKiemLichSuCuTru_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_LichSuCuTru).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_HoTen;
        private TextBox textBox_SoCCCD;
        private Label label1;
        private Label label2;
        private Label label8;
        private DateTimePicker dateTimePicker_Den;
        private Label label4;
        private DateTimePicker dateTimePicker_Tu;
        private Label label3;
        private TextBox textBox_MaHoKhau;
        private ComboBox comboBox_LoaiCuTru;
        private Label label5;
        private Button button_TimKiem;
        private DataGridView dataGridView_LichSuCuTru;
        private Button button_Thoat;
        private Label label7;
        private ComboBox comboBox_Tinh;
        private Label label6;
        private ComboBox comboBox_Xa;
        private Button button_DatLai;
        private Label label9;
    }
}