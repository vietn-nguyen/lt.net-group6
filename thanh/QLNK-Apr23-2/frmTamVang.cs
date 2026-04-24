using QuanLyNhanKhau_Nhom6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLNK
{
    public partial class frmTamVang : Form
    {

        //khoi tao ket noi
        KETNOI_CSDL knn = new KETNOI_CSDL();
        public frmTamVang()
        {
            InitializeComponent();
        }
        
        private void Load_BangTamVang()
        {
            DataTable dta = new DataTable();
            dta = knn.LayBang("SELECT NK.soCCCD, NK.hoTen, LS.tuNgay, LS.denNgay, LS.ghiChu FROM NhanKhau NK INNER JOIN LichSuCuTru LS ON NK.id = LS.id_NK WHERE LS.loaiCuTru = N'Tạm vắng'");
            dtaTamVang.DataSource = dta;
        }
        private void frmTamVang_Load(object sender, EventArgs e)
        {
            Load_BangTamVang();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
            txtHoTen.Text = "";
            txtID.Text = "";
            txtLydo.Text = "";
            cboLoai.Text = "Tạm vắng";
            txtCCCD.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            knn.KetNoi_DuLieu();
            string str = "SELECT id_NK from LichSuCuTru WHERE id_NK = '" + txtCCCD.Text + "' AND loaiCuTru = N'Tạm vắng'";
            SqlCommand cmd = new SqlCommand(str, knn.cnn);
            SqlDataReader doc_DL = cmd.ExecuteReader();
            if (doc_DL.Read() == true)
            {
                MessageBox.Show("Cong dan nay da dang ky tam vang!", "Thong bao");
                txtCCCD.Focus();
                doc_DL.Close();
                doc_DL.Dispose();
            }
            else
            {
                string sql = "INSERT INTO LichSuCuTru (id_NK, loaiCuTru, tuNgay, denNgay, ghiChu) VALUES ('"+txtCCCD.Text+"', '"+cboLoai.Text+"', '"+dtpNgayStart.Value+"', '"+dtpNgayEnd.Value+"', '"+txtLydo.Text+"')";
                knn.ThucThi(sql);
                Load_BangTamVang();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE LichSuCuTru SET loaiCuTru = '" + cboLoai.Text + "', tuNgay = '" + dtpNgayStart.Value + "', denNgay = '" + dtpNgayEnd + "', ghiChu = '" + txtLydo.Text + "' WHERE id_NK = '" + txtCCCD.Text + "'";
            knn.ThucThi(sql);
            Load_BangTamVang();
        }
    }
}
