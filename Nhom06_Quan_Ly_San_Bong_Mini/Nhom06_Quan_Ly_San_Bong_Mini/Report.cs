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
    public partial class Report : Form
    {
        DBConnect dbcon = new DBConnect();
        SqlDataAdapter da_HoaDon;
        private string _email;
        private int _tongtien;
        private int _madatsan;
        private string _mahoadon;
        public Report()
        {
            InitializeComponent();
        }
         public Report(int MaDatSan,string Email,int TongTien)
            : this()
        {
            _email = Email;
            _madatsan = MaDatSan;
            _tongtien = TongTien;
        }

         //public Report( string Email)
         //    : this()
         //{
         //    _email = Email;
             
         //}
         public int create_HoaDon()
         {
             tbl_MaHoadon.Clear();
             int a = dbcon.execute_NonQuery("insert into HoaDon Values("+_madatsan+",'"+_email+"',"+_tongtien+")");
             
             tbl_MaHoadon = dbcon.getDatatable("select max(MaHoaDon) as 'mahoadon' from HoaDon", "tbl_HoaDon");
             _mahoadon = tbl_MaHoadon.Rows[0]["mahoadon"].ToString();
             return a;
         }
         DataTable tbl_MaHoadon = new DataTable();
         private void Report_Load(object sender, EventArgs e)
         {
             if (create_HoaDon() > 0)
             {
                 MyReport rpt = new MyReport();
                 rpt.SetParameterValue("LOCMAHOADON", _mahoadon);
                 crystalReportViewer1.ReportSource = rpt;
                 rpt.SetDatabaseLogon("sa", "123456", "LAPTOP-TAITHANH\\TAITHANHSQL", "QL_SANBONG");
             }
             else
                 MessageBox.Show("Ko Tao Duoc Hoa Don");
         }
         }
         
    }
