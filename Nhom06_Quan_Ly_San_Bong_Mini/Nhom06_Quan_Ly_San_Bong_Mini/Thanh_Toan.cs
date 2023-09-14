using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADO;
using System.Data.SqlClient;
namespace Nhom06_Quan_Ly_San_Bong_Mini
{
    public partial class Thanh_Toan : Form
    {
        DBConnect dbcon = new DBConnect();
        string email;
        SqlDataAdapter da_thanhtoan;
        public Thanh_Toan()
        {
            InitializeComponent();
        }
         public Thanh_Toan(string Email)
            : this()
        {
            email = Email;
        }

        public void loadcbo_San()
        {
            string sqlselect = "select * from san";
            DataTable dt_san = dbcon.getDatatable(sqlselect, "San");
            DataRow dr = dbcon.DS.Tables["San"].NewRow();
            dr["MaSan"] = 0;
            dr["TenSan"] = "No Selection"; // or "No Selection"

            dbcon.DS.Tables["San"].Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt_san;
            comboBox1.DisplayMember = "TenSan";
            comboBox1.ValueMember = "MaSan";
            comboBox1.SelectedIndex = 1;
        }

        private void Thanh_Toan_Load(object sender, EventArgs e)
        {
            loadcbo_San();
        }
        DataTable dt_tg = new DataTable();
        float tongtien = 0;
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            dt_tg.Clear();
            string sqlselect = "exec Thoi_gian_da_hom_nay '"+comboBox1.SelectedValue.ToString()+"'";
            dt_tg = dbcon.execute_NonQuery_SP(sqlselect);
            comboBox2.DataSource = dt_tg;
            comboBox2.DisplayMember = "Thoi Gian Da";
            comboBox2.ValueMember = "MaDatSan";

        }       
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
                dt_tien.Clear();
                string sqlselect = "select San.GiaThue,datepart(hour,TGVao)as'GioVao',DATEPART(HOUR,TGRa)as'GioRa',(datediff(MINUTE,TGVao,TGRa))*GiaThue as 'Tien' from DatSan,San where MaDatSan='" + comboBox2.SelectedValue.ToString() + "' and DatSan.MaSan=San.MaSan";
                dt_tien = dbcon.getDatatable(sqlselect, "TG1");
                if (int.Parse(dt_tien.Rows[0]["GioRa"].ToString()) < 18)
                {
                    lbl_tongtien.Text = (int.Parse(dt_tien.Rows[0]["Tien"].ToString()) / 60).ToString();
                }
                else if (int.Parse(dt_tien.Rows[0]["GioVao"].ToString()) >= 18)
                {
                    lbl_tongtien.Text = ((int.Parse(dt_tien.Rows[0]["Tien"].ToString()) / 60) + (30 * (int.Parse(dt_tien.Rows[0]["Tien"].ToString()) / 60) / 100)).ToString();
                }
                else
                {
                    lbl_tongtien.Text = ((18 - int.Parse(dt_tien.Rows[0]["GioVao"].ToString())) * int.Parse(dt_tien.Rows[0]["GiaThue"].ToString()) + (int.Parse(dt_tien.Rows[0]["GioRa"].ToString()) - 18) * int.Parse(dt_tien.Rows[0]["GiaThue"].ToString()) * 30 / 100 + (int.Parse(dt_tien.Rows[0]["GioRa"].ToString()) - 18) * int.Parse(dt_tien.Rows[0]["GiaThue"].ToString())).ToString();
                }
                //MessageBox.Show("tổng hóa đơn là " + lbl_tongtien.Text + " VND,Cám ơn quý khách");
                Report rpt = new Report(int.Parse(comboBox2.SelectedValue.ToString()), email, int.Parse(lbl_tongtien.Text));
                rpt.Show();       
        }
        DataTable dt_tien = new DataTable();


        private void linklbl_chitiet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
