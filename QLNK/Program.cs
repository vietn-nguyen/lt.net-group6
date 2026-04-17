using QLNK;
using System;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }

    /// <summary>
    /// Lưu thông tin phiên đăng nhập hiện tại (dùng cho CONTEXT_INFO của SQL).
    /// </summary>
    public static class UserSession
    {
        public static int CurrentUserId = -1;
    }
}