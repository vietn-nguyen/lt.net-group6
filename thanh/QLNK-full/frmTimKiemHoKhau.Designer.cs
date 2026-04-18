namespace QLNK
{
    partial class frmTimKiemHoKhau
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

        private void InitializeComponent()
        {
            this.txtMaHK = new System.Windows.Forms.TextBox();
            this.txtCCCDChuHo = new System.Windows.Forms.TextBox();
            this.cboTinh = new System.Windows.Forms.ComboBox();
            this.cboXa = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dtaKetQua = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaHK
            // 
            this.txtMaHK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHK.Location = new System.Drawing.Point(274, 103);
            this.txtMaHK.Name = "txtMaHK";
            this.txtMaHK.Size = new System.Drawing.Size(710, 38);
            this.txtMaHK.TabIndex = 0;
            // 
            // txtCCCDChuHo
            // 
            this.txtCCCDChuHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCDChuHo.Location = new System.Drawing.Point(274, 179);
            this.txtCCCDChuHo.Name = "txtCCCDChuHo";
            this.txtCCCDChuHo.Size = new System.Drawing.Size(710, 38);
            this.txtCCCDChuHo.TabIndex = 1;
            // 
            // cboTinh
            // 
            this.cboTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinh.Location = new System.Drawing.Point(274, 245);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(710, 39);
            this.cboTinh.TabIndex = 2;
            // 
            // cboXa
            // 
            this.cboXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboXa.Location = new System.Drawing.Point(274, 325);
            this.cboXa.Name = "cboXa";
            this.cboXa.Size = new System.Drawing.Size(710, 39);
            this.cboXa.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(274, 405);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(710, 38);
            this.txtDiaChi.TabIndex = 4;
            // 
            // dtaKetQua
            // 
            this.dtaKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtaKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtaKetQua.Location = new System.Drawing.Point(55, 482);
            this.dtaKetQua.Name = "dtaKetQua";
            this.dtaKetQua.RowHeadersWidth = 82;
            this.dtaKetQua.Size = new System.Drawing.Size(1280, 580);
            this.dtaKetQua.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Hộ Khẩu:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 47);
            this.label2.TabIndex = 7;
            this.label2.Text = "CCCD Chủ Hộ:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tỉnh/TP:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 51);
            this.label4.TabIndex = 9;
            this.label4.Text = "Xã/Phường:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa chỉ:";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(50, 30);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(818, 50);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "TÌM KIẾM THÔNG TIN HỘ KHẨU";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1107, 395);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(193, 57);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmTimKiemHoKhau
            // 
            this.ClientSize = new System.Drawing.Size(1388, 1098);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMaHK);
            this.Controls.Add(this.txtCCCDChuHo);
            this.Controls.Add(this.cboTinh);
            this.Controls.Add(this.cboXa);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.dtaKetQua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmTimKiemHoKhau";
            this.Text = "Tra cứu Hộ Khẩu";
            this.Load += new System.EventHandler(this.frmTimKiemHoKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Khai báo các biến control
        private System.Windows.Forms.TextBox txtMaHK, txtCCCDChuHo, txtDiaChi;
        private System.Windows.Forms.ComboBox cboTinh, cboXa;
        private System.Windows.Forms.DataGridView dtaKetQua;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, lblHeader;
        private System.Windows.Forms.Button btnSearch;
    }
}