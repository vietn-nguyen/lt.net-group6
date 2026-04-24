namespace QuanLyNhanKhau_Nhom6
{
    partial class frmTimKiemNhanKhau
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
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.cboTieuChi = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtaKetQua = new System.Windows.Forms.DataGridView();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.lblTieuChi = new System.Windows.Forms.Label();
            this.lblTimKiemNhanKhau = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuKhoa.Location = new System.Drawing.Point(304, 168);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(383, 43);
            this.txtTuKhoa.TabIndex = 0;
            // 
            // cboTieuChi
            // 
            this.cboTieuChi.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTieuChi.FormattingEnabled = true;
            this.cboTieuChi.Items.AddRange(new object[] {
            "Họ tên",
            "Số CCCD"});
            this.cboTieuChi.Location = new System.Drawing.Point(304, 229);
            this.cboTieuChi.Name = "cboTieuChi";
            this.cboTieuChi.Size = new System.Drawing.Size(383, 45);
            this.cboTieuChi.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(779, 225);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(147, 52);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtaKetQua
            // 
            this.dtaKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtaKetQua.Location = new System.Drawing.Point(78, 321);
            this.dtaKetQua.Name = "dtaKetQua";
            this.dtaKetQua.RowHeadersWidth = 82;
            this.dtaKetQua.RowTemplate.Height = 33;
            this.dtaKetQua.Size = new System.Drawing.Size(1347, 176);
            this.dtaKetQua.TabIndex = 3;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(71, 171);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(112, 37);
            this.lblTuKhoa.TabIndex = 4;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // lblTieuChi
            // 
            this.lblTieuChi.AutoSize = true;
            this.lblTieuChi.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuChi.Location = new System.Drawing.Point(71, 233);
            this.lblTieuChi.Name = "lblTieuChi";
            this.lblTieuChi.Size = new System.Drawing.Size(186, 37);
            this.lblTieuChi.TabIndex = 5;
            this.lblTieuChi.Text = "Tìm kiếm theo";
            // 
            // lblTimKiemNhanKhau
            // 
            this.lblTimKiemNhanKhau.AutoSize = true;
            this.lblTimKiemNhanKhau.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemNhanKhau.Location = new System.Drawing.Point(71, 55);
            this.lblTimKiemNhanKhau.Name = "lblTimKiemNhanKhau";
            this.lblTimKiemNhanKhau.Size = new System.Drawing.Size(616, 71);
            this.lblTimKiemNhanKhau.TabIndex = 6;
            this.lblTimKiemNhanKhau.Text = "TÌM KIẾM NHÂN KHẨU";
            // 
            // frmTimKiemNhanKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 560);
            this.Controls.Add(this.lblTimKiemNhanKhau);
            this.Controls.Add(this.lblTieuChi);
            this.Controls.Add(this.lblTuKhoa);
            this.Controls.Add(this.dtaKetQua);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cboTieuChi);
            this.Controls.Add(this.txtTuKhoa);
            this.Name = "frmTimKiemNhanKhau";
            this.Text = "Tìm kiếm nhân khẩu";
            this.Load += new System.EventHandler(this.frmTimKiemNhanKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.ComboBox cboTieuChi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dtaKetQua;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.Label lblTieuChi;
        private System.Windows.Forms.Label lblTimKiemNhanKhau;
    }
}