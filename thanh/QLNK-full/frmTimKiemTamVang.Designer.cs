namespace QLNK
{
    partial class frmTimKiemTamVang
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
            this.lblTimKiemNhanKhau = new System.Windows.Forms.Label();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.dtaKetQua = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimKiemNhanKhau
            // 
            this.lblTimKiemNhanKhau.AutoSize = true;
            this.lblTimKiemNhanKhau.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemNhanKhau.Location = new System.Drawing.Point(82, 87);
            this.lblTimKiemNhanKhau.Name = "lblTimKiemNhanKhau";
            this.lblTimKiemNhanKhau.Size = new System.Drawing.Size(917, 71);
            this.lblTimKiemNhanKhau.TabIndex = 13;
            this.lblTimKiemNhanKhau.Text = "TÌM KIẾM NHÂN KHẨU TẠM VẮNG";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(87, 219);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(122, 37);
            this.lblTuKhoa.TabIndex = 11;
            this.lblTuKhoa.Text = "Số CCCD";
            // 
            // dtaKetQua
            // 
            this.dtaKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtaKetQua.Location = new System.Drawing.Point(89, 333);
            this.dtaKetQua.Name = "dtaKetQua";
            this.dtaKetQua.RowHeadersWidth = 82;
            this.dtaKetQua.RowTemplate.Height = 33;
            this.dtaKetQua.Size = new System.Drawing.Size(1347, 482);
            this.dtaKetQua.TabIndex = 10;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1277, 211);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(147, 52);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtCCCD
            // 
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCD.Location = new System.Drawing.Point(320, 216);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(739, 43);
            this.txtCCCD.TabIndex = 7;
            // 
            // frmTimKiemTamVang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 904);
            this.Controls.Add(this.lblTimKiemNhanKhau);
            this.Controls.Add(this.lblTuKhoa);
            this.Controls.Add(this.dtaKetQua);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtCCCD);
            this.Name = "frmTimKiemTamVang";
            this.Text = "frmTimKiemTamVang";
            this.Load += new System.EventHandler(this.frmTimKiemTamVang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtaKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimKiemNhanKhau;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.DataGridView dtaKetQua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtCCCD;
    }
}