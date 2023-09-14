using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nhom06_Quan_Ly_San_Bong_Mini
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

            Application.Run(new Dang_Nhap());
            //Application.Run(new Dang_Ky());
            //Application.Run(new Quen_Mat_Khau());
            //Application.Run(new Dat_San());
            //Application.Run(new Nhan_San());
            //Application.Run(new Thong_Tin_Ca_Nhan());
            //Application.Run(new Thanh_Toan());
            //Application.Run(new Report());   
            //Application.Run(new Quan_Ly());
        }
    }
}
