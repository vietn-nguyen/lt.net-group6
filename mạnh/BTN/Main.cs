
using System.Data;
namespace BTN
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }
        private void LoadHoKhau()
        {
            Database db = new Database();
            string query = "SELECT * FROM HoKhau WHERE isDeleted=0";
            DataTable dt = db.ExecuteQuery(query);
            dataGridView_HoKhau.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            string query = "SELECT * FROM HoKhau WHERE isDeleted=0";
            DataTable dt = db.ExecuteQuery(query);
            dataGridView_HoKhau.DataSource = dt;
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            ThemHoKhau addForm = new ThemHoKhau();

            // mở dạng dialog (khóa form chính lại)
            var result = addForm.ShowDialog();

            // nếu thêm thành công thì reload lại grid
            if (result == DialogResult.OK)
            {
                LoadHoKhau();
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            SuaHoKhau editForm = new SuaHoKhau();

            // mở dạng dialog (khóa form chính lại)
            var result = editForm.ShowDialog();

            // nếu thêm thành công thì reload lại grid
            if (result == DialogResult.OK)
            {
                LoadHoKhau();
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            XoaHoKhau deleteForm = new XoaHoKhau();

            // mở dạng dialog (khóa form chính lại)
            var result = deleteForm.ShowDialog();

            // nếu thêm thành công thì reload lại grid
            if (result == DialogResult.OK)
            {
                LoadHoKhau();
            }
        }

        private void button_TimKiemTamTru_Click(object sender, EventArgs e)
        {
            TimKiemTamTru form = new TimKiemTamTru();

            // mở dạng dialog (khóa form chính lại)
            var result = form.ShowDialog();

        }

        private void button_ThemTamTru_Click(object sender, EventArgs e)
        {
            ThemTamTru form = new ThemTamTru();

            // mở dạng dialog (khóa form chính lại)
            var result = form.ShowDialog();


        }

        private void button_SuaTamTru_Click(object sender, EventArgs e)
        {
            SuaTamTru form = new SuaTamTru();
            var result = form.ShowDialog();
        }

        private void button_XoaTamTru_Click(object sender, EventArgs e)
        {
            XoaTamTru form = new XoaTamTru();
            var result = form.ShowDialog();
        }

        private void button_TimKiemLichSuCuTru_Click(object sender, EventArgs e)
        {
            TimKiemLichSuCuTru form = new TimKiemLichSuCuTru();
            var result = form.ShowDialog();
        }
        private void button_TimKiemNhatKyTruyVet_Click(object sender, EventArgs e)
        {
            TimKiemNhatKyTruyVet form = new TimKiemNhatKyTruyVet();
            var result = form.ShowDialog();
        }
    }
}
