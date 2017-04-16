using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DXApplication1
{
    static class Program
    {
        public static frmMain mainForm = null;
        public static frmDangNhap loginForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDanhMucBoPhan());
        }
    }
}
