namespace BTN
{
    partial class SuaHoKhau
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
            textBox_Ma_HoKhau = new TextBox();
            label1 = new Label();
            comboBox_Xa = new ComboBox();
            label2 = new Label();
            textBox_DiaChi = new TextBox();
            label3 = new Label();
            dateTimePicker_NgayLap = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            checkBox_Xoa = new CheckBox();
            button_Sua = new Button();
            button_Thoat = new Button();
            dataGridView_HoKhau = new DataGridView();
            comboBox_Tinh = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).BeginInit();
            SuspendLayout();
            // 
            // textBox_Ma_HoKhau
            // 
            textBox_Ma_HoKhau.Location = new Point(158, 86);
            textBox_Ma_HoKhau.Name = "textBox_Ma_HoKhau";
            textBox_Ma_HoKhau.Size = new Size(151, 27);
            textBox_Ma_HoKhau.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 89);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã hộ khẩu";
            // 
            // comboBox_Xa
            // 
            comboBox_Xa.FormattingEnabled = true;
            comboBox_Xa.Location = new Point(158, 182);
            comboBox_Xa.Name = "comboBox_Xa";
            comboBox_Xa.Size = new Size(151, 28);
            comboBox_Xa.TabIndex = 2;
            comboBox_Xa.SelectedIndexChanged += comboBox_Xa_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 185);
            label2.Name = "label2";
            label2.Size = new Size(26, 20);
            label2.TabIndex = 3;
            label2.Text = "Xã";
            // 
            // textBox_DiaChi
            // 
            textBox_DiaChi.Location = new Point(158, 227);
            textBox_DiaChi.Multiline = true;
            textBox_DiaChi.Name = "textBox_DiaChi";
            textBox_DiaChi.Size = new Size(151, 34);
            textBox_DiaChi.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 230);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 5;
            label3.Text = "Địa chi";
            // 
            // dateTimePicker_NgayLap
            // 
            dateTimePicker_NgayLap.Location = new Point(158, 289);
            dateTimePicker_NgayLap.Name = "dateTimePicker_NgayLap";
            dateTimePicker_NgayLap.Size = new Size(250, 27);
            dateTimePicker_NgayLap.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 294);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 7;
            label4.Text = "Ngày Lập";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(268, 26);
            label5.Name = "label5";
            label5.Size = new Size(248, 38);
            label5.TabIndex = 8;
            label5.Text = "Form Sửa Hộ Khẩu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(487, 86);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 9;
            // 
            // checkBox_Xoa
            // 
            checkBox_Xoa.AutoSize = true;
            checkBox_Xoa.Location = new Point(548, 85);
            checkBox_Xoa.Name = "checkBox_Xoa";
            checkBox_Xoa.Size = new Size(95, 24);
            checkBox_Xoa.TabIndex = 10;
            checkBox_Xoa.Text = "Đã bị xóa";
            checkBox_Xoa.UseVisualStyleBackColor = true;
            // 
            // button_Sua
            // 
            button_Sua.Location = new Point(548, 127);
            button_Sua.Name = "button_Sua";
            button_Sua.Size = new Size(94, 29);
            button_Sua.TabIndex = 11;
            button_Sua.Text = "Sửa";
            button_Sua.UseVisualStyleBackColor = true;
            button_Sua.Click += button_Sua_Click;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(549, 171);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(94, 29);
            button_Thoat.TabIndex = 12;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // dataGridView_HoKhau
            // 
            dataGridView_HoKhau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HoKhau.Location = new Point(48, 340);
            dataGridView_HoKhau.Name = "dataGridView_HoKhau";
            dataGridView_HoKhau.RowHeadersWidth = 51;
            dataGridView_HoKhau.Size = new Size(702, 188);
            dataGridView_HoKhau.TabIndex = 13;
            dataGridView_HoKhau.CellClick += dataGridView_HoKhau_CellClick;
            // 
            // comboBox_Tinh
            // 
            comboBox_Tinh.FormattingEnabled = true;
            comboBox_Tinh.Location = new Point(158, 138);
            comboBox_Tinh.Name = "comboBox_Tinh";
            comboBox_Tinh.Size = new Size(151, 28);
            comboBox_Tinh.TabIndex = 14;
            comboBox_Tinh.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 138);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 15;
            label7.Text = "Tỉnh";
            // 
            // Edit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 545);
            Controls.Add(label7);
            Controls.Add(comboBox_Tinh);
            Controls.Add(dataGridView_HoKhau);
            Controls.Add(button_Thoat);
            Controls.Add(button_Sua);
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
            Name = "Edit";
            Text = "Edit";
            Load += Edit_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_HoKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Ma_HoKhau;
        private Label label1;
        private ComboBox comboBox_Xa;
        private Label label2;
        private TextBox textBox_DiaChi;
        private Label label3;
        private DateTimePicker dateTimePicker_NgayLap;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox checkBox_Xoa;
        private Button button_Sua;
        private Button button_Thoat;
        private DataGridView dataGridView_HoKhau;
        private ComboBox comboBox_Tinh;
        private Label label7;
    }
}