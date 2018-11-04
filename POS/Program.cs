using System;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class LoginInfo
    {
        public static int IDUser;
        public static string UserName;
        public static string CheckInTime;
    }
}
