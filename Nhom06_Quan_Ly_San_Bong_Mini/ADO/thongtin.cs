using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ADO
{
    public class thongtin
    {
        private string hoten, email, diachi, sdt, mk;
        

        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public string MatKhau
        {
            get { return mk; }
            set { mk = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public thongtin(string a, string b, string c, string d, string e)
        {
            this.Email = a;
            this.HoTen = b;
            this.DiaChi = c;
            this.SDT = d;
            this.MatKhau = e;
        }

        public thongtin(DataRow row)
        {
            this.Email = row["Email"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.SDT = row["SDT"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
        }
    
    }
}
