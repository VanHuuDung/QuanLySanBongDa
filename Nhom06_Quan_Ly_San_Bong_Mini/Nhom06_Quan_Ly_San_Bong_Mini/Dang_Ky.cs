using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ADO;
namespace Nhom06_Quan_Ly_San_Bong_Mini
{
    public partial class Dang_Ky : Form
    {
        DBConnect dbconn = new DBConnect();
        public Dang_Ky()
        {
            InitializeComponent();
        }
        public bool KT_Matkhau(string mk)
        {
            return Regex.IsMatch(mk, @"^[a-zA-Z0-9]{5,30}$");
        }

        public static bool KT_email(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,40}@gmail.com(.vn|)$");
        }

        public bool KT_trung_email(string email)
        {
            dbconn.openConnecttion();
            string selectstring = "select * from Users where Email = '" + email + "'";
            SqlDataReader kt = dbconn.execute_Reader(selectstring);
            if (kt.HasRows)
            {
                kt.Close();
                dbconn.closedConnecttion();
                return true;
            }
            else
            {
                kt.Close();
                dbconn.closedConnecttion();
                return false;
            }
        }

        public void kt_thongtin(string email, string matkhau, string sdt, string hoten)
        {
            bool check = true;
            if (email == "")
            {
                check = false;
                lbl_email.Text = "(*)";
                lbl_email.ForeColor = System.Drawing.Color.Red;
            }
            if (matkhau == "")
            {
                check = false;
                lbl_matkhau.Text = "(*)";
                lbl_matkhau.ForeColor = System.Drawing.Color.Red;
            }
            if (sdt == "")
            {
                check = false;
                lbl_sdt.Text = "(*)";
                lbl_sdt.ForeColor = System.Drawing.Color.Red;
            }
            if (hoten == "")
            {
                check = false;
                lbl_hoten.Text = "(*)";
                lbl_hoten.ForeColor = System.Drawing.Color.Red;
            }
            if (check == false)
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin");
            }
        }

        private void Dang_Ky_Load(object sender, EventArgs e)
        {

        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
             string email = txt_email.Text;
            string matkhau = txt_matkhau.Text;
            string sdt = txt_SoDienThoai.Text;
            string xacnhanmk = txt_xacnhan_mk.Text;
            string hoten = txt_hoten.Text;
            string diachi = txt_diachi.Text;
            kt_thongtin(email, matkhau, sdt, hoten);
            if (!KT_email(email))
            {
                MessageBox.Show("Email không chính xác");
            }
            else if (!KT_Matkhau(matkhau))
            {
                MessageBox.Show("Mật khẩu không được chứa ký tự đặt biệt. Độ dài từ 5 đến 30 ký tự");
            }
            else if (!KT_Matkhau(sdt))
            {
                MessageBox.Show("Số điện thoại không được chứa ký tự đặt biệt. Độ dài từ 5 đến 30 ký tự");
            }     
            else if (xacnhanmk != matkhau)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
            else
            {
                try
                {
                    if (KT_trung_email(email) == false)
                    {
                        string insertString = "insert into Users values('" + email + "', N'" + hoten + "', '" + sdt + "', N'" + diachi + "', '" + matkhau + "')";
                        int kq = dbconn.execute_NonQuery(insertString);
                        if (kq > 0)
                            MessageBox.Show("Đăng ký thành công");
                    }
                    else
                    {
                        MessageBox.Show("Email đã được đăng ký");
                    }
                }
                catch
                {
                    MessageBox.Show("Đăng ký không thành công");
                }
            }

        }

        private void Dang_Ky_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dang_Nhap a = new Dang_Nhap();
            this.Hide();
            a.ShowDialog();
        }
       
    }
}
