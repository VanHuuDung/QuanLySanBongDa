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
    public partial class Quen_Mat_Khau : Form
    {
        DBConnect dbconn = new DBConnect();
        public Quen_Mat_Khau()
        {
            InitializeComponent();
        }
        public bool KT_dangnhap(string email)
        {
            dbconn.openConnecttion();
            string selectstring = "select * from Users where Email = '" + email + "'";
            SqlDataReader kt = dbconn.execute_Reader(selectstring);
            if (kt.HasRows)
            {
                kt.Close();
                dbconn.closedConnecttion();
                return false;
            }
            else
            {
                kt.Close();
                dbconn.closedConnecttion();
                return true;
            }
        }
        public void Load_textbox(string email)
        {
            string selectstring = "select * from Users where Email = '" + email + "'";
            DataTable dt_khoa = dbconn.getDatatable(selectstring, "dbo.MatKhau");
            txt_matkhau.DataBindings.Clear();
            txt_matkhau.DataBindings.Add("Text", dt_khoa, "MatKhau");
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (txt_email.Text.Trim() == "")
                MessageBox.Show("Bạn chưa nhập email");
            else
            {
                if (KT_dangnhap(txt_email.Text.Trim()) == true)
                {
                    MessageBox.Show("Email không tồn tại");
                    txt_email.ResetText();
                    txt_matkhau.ResetText();
                }
                else
                {
                    Load_textbox(txt_email.Text.Trim());
                }
            }
        }

        private void Quen_Mat_Khau_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dang_Nhap a = new Dang_Nhap();
            this.Hide();
            a.ShowDialog();
        }
    }
}
