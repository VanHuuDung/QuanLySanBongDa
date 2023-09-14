using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ADO;

namespace Nhom06_Quan_Ly_San_Bong_Mini
{
    public partial class Thong_Tin_Ca_Nhan : Form
    {
        DBConnect dbconn = new DBConnect();
        private string email;

        public Thong_Tin_Ca_Nhan()
        {
            InitializeComponent();
            label1.AutoSize = false;
            label1.Height = 2;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Width = 650;


        }

        public Thong_Tin_Ca_Nhan(string Email)
            : this()
        {
            email = Email;
        }

        public void load_Thongtin()
        {
            List<thongtin> List_tt = new List<thongtin>();
            string selectstring = "select * from Users where Email = '" + email + "'";
            DataTable dt_tt = dbconn.getDatatable(selectstring, "dbo.Users");
            foreach (DataRow item in dt_tt.Rows)
            {
                thongtin san = new thongtin(item);
                List_tt.Add(san);
            }

            foreach (thongtin item in List_tt)
            {
                lbl_email.Text = item.Email;
                lbl_hoten.Text = item.HoTen;
                lbl_diachi.Text = item.DiaChi;
                lbl_sdt.Text = item.SDT;
            }
        }

        

        private void Thong_Tin_Ca_Nhan_Load(object sender, EventArgs e)
        {
            load_Thongtin();
        }

        private void btn_thaydoi_Click_1(object sender, EventArgs e)
        {
            dbconn.openConnecttion();
            string selectstring = "select * from Users where Email = '" + email + "' and MatKhau = '" + txt_matkhaucu.Text + "'";
            SqlDataReader kt = dbconn.execute_Reader(selectstring);
            if (kt.HasRows)
            {
                kt.Close();
                dbconn.closedConnecttion();
                if (txt_matkhaumoi.Text == txt_XacNhanMK.Text)
                {
                    string insertString = "update Users set MatKhau = '" + txt_matkhaumoi.Text + "' where Email = '" + email + "'";
                    int kq = dbconn.execute_NonQuery(insertString);
                    if (kq > 0)
                        MessageBox.Show("Sua thanh cong");
                }
                else
                    MessageBox.Show("xac nhan mat khau khong dung");

            }
            else
            {
                MessageBox.Show("no okk");
                kt.Close();
                dbconn.closedConnecttion();
            }
        }
    }
}
