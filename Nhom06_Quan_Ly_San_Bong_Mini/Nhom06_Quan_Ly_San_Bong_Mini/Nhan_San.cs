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
    public partial class Nhan_San : Form
    {
        DBConnect dbcon = new DBConnect();

        SqlDataAdapter da_NhanSan;
        public Nhan_San()
        {
            InitializeComponent();
        }
        public void create_tblNhanSan()
        {
            da_NhanSan = new SqlDataAdapter("select * from DatSan", dbcon.Connect);

            da_NhanSan.Fill(dbcon.DS, "tblNhanSan");
            //gan khoa chinh cho tblLop
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dbcon.DS.Tables["tblNhanSan"].Columns["MaDatSan"];
            dbcon.DS.Tables["tblNhanSan"].PrimaryKey = primarykey;
        }
        void databingding(DataTable pDT)
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", pDT, "TenKhachHang");
            textBox2.DataBindings.Add("Text", pDT, "SDTKhachHang");
            textBox3.DataBindings.Add("Text", pDT, "TenSan");
            textBox4.DataBindings.Add("Text", pDT, "TGVao");
            textBox5.DataBindings.Add("Text", pDT, "TGRa");

        }
        void Load_gridview()
        {
            //string test="select KhachHang.TenKhachHang,San.TenSan,DatSan.*, GETDATE() as 'now' from DatSan,KhachHang,San where DatSan.SDTKhachHang=KhachHang.SDT and san.MaSan=DatSan.MaSan and NgayDat=Getdate()"
            string sqlselect = "select * from F_DanhSachDatSanHomNay()";
            dataGridView1.DataSource = dbcon.getDatatable(sqlselect, "tblNhanSan");
            DataTable time = dbcon.getDatatable("select getdate() as 'now'", "tblnow");
            lb_Now.Text = time.Rows[0]["now"].ToString();
            databingding(dbcon.DS.Tables["tblNhanSan"]);            
        }
        public void fulltxtenable()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
 
        }
        private void Nhan_San_Load(object sender, EventArgs e)
        {
            Load_gridview();
            fulltxtenable();
        }
        DataTable a = new DataTable();
        public void LoadGridByKeyWord()
        {
            a.Clear();
            a = dbcon.getDatatable("select KhachHang.TenKhachHang,San.TenSan,DatSan.* from DatSan,KhachHang,San where DatSan.SDTKhachHang=KhachHang.SDT and san.MaSan=DatSan.MaSan and TenKhachHang like'%" + txt_timkiem.Text + "%' and NgayDat=CONVERT(date,GETDATE())", "tblSearch");
            dataGridView1.DataSource = a;
            databingding(a);
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            LoadGridByKeyWord();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            LoadGridByKeyWord();
        }

        private void btn_NhanSan_Click(object sender, EventArgs e)
        {
            if (dbcon.DS.Tables["tblNhanSan"].Rows.Count > 0)
            {
                MessageBox.Show("Nhận Sân Thành Công", "Congratulation!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không có sân hôm nay", "Congratulation!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }
    }
}
