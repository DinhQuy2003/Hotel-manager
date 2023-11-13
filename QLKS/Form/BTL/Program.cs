using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public class Bientoancuc
    {
        public static string TCconnstr = @"Data Source=QUY\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
        public static string tenks;
        public static string tenchuks;
        public static string diachi;
        public static string sdt;
        public static string masothue;
        public static DateTime ngaythanhlap;
        public static string vitri;
        public static string logofile;
    }
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
            Application.Run(new fdangnhap());
        }
    }
}
