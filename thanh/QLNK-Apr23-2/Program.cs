using QLNK;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Added this for DllImport

namespace QuanLyNhanKhau_Nhom6
{
    internal static class Program
    {
        // 1. Import the Windows function to disable scaling
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            // 2. Call the function before the application loads
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

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