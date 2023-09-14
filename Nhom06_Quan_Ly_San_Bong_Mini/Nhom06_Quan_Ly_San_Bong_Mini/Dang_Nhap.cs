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
    public partial class Dang_Nhap : Form
    {
        DBConnect dbconn = new DBConnect();
        SqlDataReader kt;

        public Dang_Nhap()
        {
            InitializeComponent();
        }

        private void linklbl_quen_mk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quen_Mat_Khau quenmk = new Quen_Mat_Khau();
            this.Hide();
            quenmk.ShowDialog();
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            Dang_Ky dangky = new Dang_Ky();
            this.Hide();
            dangky.ShowDialog();
        }

        public bool KT_dangnhap(string email, string pass)
        {
            dbconn.openConnecttion();
            string selectstring = "select * from Users where Email = '" + email + "' and MatKhau = '" + pass + "'";
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

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string email = txt_username.Text;
            string matkhau = txt_password.Text;
            if (email.Trim() == "")
                MessageBox.Show("bạn chưa nhập email");
            else if (matkhau.Trim() == "")
                MessageBox.Show("bạn chưa nhập mật khẩu");
            else
            {
                if (KT_dangnhap(email, matkhau) == true)
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                else
                {
                    Dat_San datsan = new Dat_San(email);
                                      
                    this.Hide();
                    datsan.ShowDialog();
                }

            }
        }

        private void linklbl_quen_mk_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quen_Mat_Khau quenmk = new Quen_Mat_Khau();
            this.Hide();
            quenmk.ShowDialog();
        }


    }
}
