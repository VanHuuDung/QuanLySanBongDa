using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ADO;
namespace Nhom06_Quan_Ly_San_Bong_Mini
{
    public partial class Quan_Ly : Form
    {
        DBConnect dbcon = new DBConnect();
        SqlDataAdapter da_User;
        DataTable tbl_User = new DataTable();
        public void create_tblUser()
        {
            tbl_User.Clear();
            tbl_User = dbcon.getDatatable("select * from Users", "tblUser");
          
            //da_User = new SqlDataAdapter("select * from Users", dbcon.Connect);
            //da_User.Fill(dbcon.DS, "tblUser");           
            //gan khoa chinh cho tblLop
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dbcon.DS.Tables["tblUser"].Columns["Email"];
            dbcon.DS.Tables["tblUser"].PrimaryKey = primarykey;
        }
        public void create_tblSan()
        {

            da_User = new SqlDataAdapter("select * from San", dbcon.Connect);

            da_User.Fill(dbcon.DS, "tblSan");
            //gan khoa chinh cho tblLop
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dbcon.DS.Tables["tblSan"].Columns["MaSan"];
            dbcon.DS.Tables["tblSan"].PrimaryKey = primarykey;
        }
        public void create_tblKhachHang()
        {

            da_User = new SqlDataAdapter("select * from KhachHang", dbcon.Connect);

            da_User.Fill(dbcon.DS, "tblKH");
            //gan khoa chinh cho tblLop
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dbcon.DS.Tables["tblKH"].Columns["SDT"];
            dbcon.DS.Tables["tblKH"].PrimaryKey = primarykey;
        }

        public void create_tblHoaDon()
        {
            da_User = new SqlDataAdapter("select * from HoaDon", dbcon.Connect);

            da_User.Fill(dbcon.DS, "tblHoaDon");
            //gan khoa chinh cho tblLop
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dbcon.DS.Tables["tblHoaDon"].Columns["MaHoaDon"];
            dbcon.DS.Tables["tblHoaDon"].PrimaryKey = primarykey;
        }
        void databingding_NhanVien(DataTable pDT)
        {
            txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.DataBindings.Clear();
            txt_admin_QuanLyNhanVien_NhanVienInfo_Password.DataBindings.Clear();
            txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.DataBindings.Clear();
            txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.DataBindings.Clear();
            txt_admin_QuanLyNhanVien_NhanVienInfo_Address.DataBindings.Clear();
            txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.DataBindings.Add("Text", pDT, "Email");
            txt_admin_QuanLyNhanVien_NhanVienInfo_Password.DataBindings.Add("Text", pDT, "MatKhau");
            txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.DataBindings.Add("Text", pDT, "HoTen");
            txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.DataBindings.Add("Text", pDT, "SDT");
            txt_admin_QuanLyNhanVien_NhanVienInfo_Address.DataBindings.Add("Text", pDT, "DiaChi");
        }
        void databingding_San(DataTable pDT)
        {
            textBox2.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", pDT, "TenSan");
            comboBox1.DataBindings.Add("Text", pDT, "MaLoai");
            textBox4.DataBindings.Add("Text", pDT, "GiaThue");
            textBox5.DataBindings.Add("Text", pDT, "MaSan");
        }
        void databingding_KhachHang(DataTable pDT)
        {
            textBox7.DataBindings.Clear();
            textBox9.DataBindings.Clear();
           
            textBox7.DataBindings.Add("Text", pDT, "SDT");
            textBox9.DataBindings.Add("Text", pDT, "TenKhachHang");
           
        }
        void Load_gridview()
        {
            dtg_admin_QLNV.DataSource = dbcon.DS.Tables["tblUser"];
            databingding_NhanVien(dbcon.DS.Tables["tblUser"]);

        }
        void Load_gridview_San()
        {
            dtg_admin_QLS.DataSource = dbcon.DS.Tables["tblSan"];
            databingding_San(dbcon.DS.Tables["tblSan"]);
        }
        void Load_gridview_KhachHang()
        {
            dtg_admin_QLKH.DataSource = dbcon.DS.Tables["tblKH"];
            databingding_KhachHang(dbcon.DS.Tables["tblKH"]);
        }
        void Load_gridview_HoaDon()
        {
            dtg_admin_QLHD.DataSource = dbcon.DS.Tables["tblHoaDon"];
        }
        public Quan_Ly()
        {
            InitializeComponent();
        }
        DataTable a = new DataTable();
        public void LoadGridByKeyWord_NhanVien()
        {
            a.Clear();
            a = dbcon.getDatatable("select * from Users where HoTen like '%" + txt_admin_QuanLyNhanVien_Search.Text + "%'", "tblSearch_NhanVien");
            dtg_admin_QLNV.DataSource = a;
            databingding_NhanVien(a);
        }
        public void LoadGridByKeyWord_San()
        {
            a.Clear();
            a = dbcon.getDatatable("select * from San where TenSan like '%" + textBox6.Text + "%'", "tblSearch_San");
            dtg_admin_QLS.DataSource = a;
            databingding_San(a);
        }
        public void LoadGridByKeyWord_KhachHang()
        {
            a.Clear();
            a = dbcon.getDatatable("select * from KhachHang where TenKhachHang like '%" + textBox10.Text + "%'", "tblSearch_KhachHang");
            dtg_admin_QLKH.DataSource = a;
            databingding_KhachHang(a);
        }
        public void LoadGridByKeyWord_HoaDon()
        {
            a.Clear();
            a = dbcon.getDatatable("select HoaDon.* from HoaDon,DatSan where  DatSan.MaDatSan=HoaDon.MaDatSan and SDTKhachHang='" + textBox1 .Text+ "'", "tblSearch_HoaDon");
            dtg_admin_QLHD.DataSource = a;
          
        }
        private void Quan_Ly_Load(object sender, EventArgs e)
        {
            load_cbo_KhachHang();
            load_cbo_NhanVien();
            load_cbo_San();
            create_tblUser();
            create_tblSan();
            create_tblKhachHang();
            create_tblHoaDon();
            Load_gridview();
            Load_gridview_San();
            Load_gridview_KhachHang();
            Load_gridview_HoaDon();
            txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Enabled = false;
            txt_admin_QuanLyNhanVien_NhanVienInfo_Password.Enabled = false;
            txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.Enabled = false;
            txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.Enabled = false;
            txt_admin_QuanLyNhanVien_NhanVienInfo_Address.Enabled = false;
            textBox9.Enabled = false;
            textBox7.Enabled = false;
            textBox2.Enabled = false;          
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            Load_cboMaLoai();
        }

      

        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            dbcon.DS.Tables["tblSearch_NhanVien"].Clear();
            Load_gridview();         
        }

        private void btn_admin_QuanLyNhanVien_ChucNang_ThemNhanVien_Click(object sender, EventArgs e)
        {
            btn_admin_QuanLyNhanVien_ChucNang_SuaNhanVien.Enabled = false;
            txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_Password.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_Address.Enabled = true;

        }
        private void btn_admin_QuanLyNhanVien_ChucNang_XoaNhanVien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete This User?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                //DataRow dr = dbcon.DS.Tables["tblUser"].Rows.Find(txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text);
                if (dbcon.Kt_Email_HoaDon(txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text) == true)
                {
                    int a = dbcon.execute_NonQuery("delete  Users where Email='" + txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text + "'");
                    if (a > 0)
                    {
                       
                        MessageBox.Show("Xóa thành công!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                        
                    }
                    Quan_Ly_Load(sender, e); 
                }
                else
                {
                    MessageBox.Show("User nay khong the xoa Vi User Dang lam Viec!!");
                    return;
                }
                
            }
        }

        private void btn_admin_QuanLyNhanVien_ChucNang_SuaNhanVien_Click(object sender, EventArgs e)
        {
            btn_admin_QuanLyNhanVien_ChucNang_ThemNhanVien.Enabled = false;

            txt_admin_QuanLyNhanVien_NhanVienInfo_Password.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.Enabled = true;
            txt_admin_QuanLyNhanVien_NhanVienInfo_Address.Enabled = true;
        }

        private void btn_admin_QuanLyNhanVien_ChucNang_Save_Click(object sender, EventArgs e)
        {
            if (btn_admin_QuanLyNhanVien_ChucNang_ThemNhanVien.Enabled == false)
            {
                DataRow dr = dbcon.DS.Tables["tblUser"].Rows.Find(txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text);
                if (dr != null)
                {
                    int a = dbcon.execute_NonQuery("update Users set HoTen=N'" + txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.Text + "',SDT='" + txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.Text + "',DiaChi=N'" + txt_admin_QuanLyNhanVien_NhanVienInfo_Address.Text + "', MatKhau='" + txt_admin_QuanLyNhanVien_NhanVienInfo_Password.Text + "' where Email='" + txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text + "'");
                    if (a > 0)
                    {
                        MessageBox.Show("Sửa Thành Công");
                    }
                    else
                        MessageBox.Show("Sửa Không Thành Công");
                    btn_admin_QuanLyNhanVien_ChucNang_ThemNhanVien.Enabled = true;
                    Quan_Ly_Load(sender, e);
                }
            }
            else
            {
                // kiểm tra khóa chính
                DataRow dr = dbcon.DS.Tables["tblUser"].Rows.Find(textBox5.Text);
                if (dr != null)
                {
                    MessageBox.Show("Trùng Email");
                    btn_admin_QuanLyNhanVien_ChucNang_SuaNhanVien.Enabled = true;
                    Quan_Ly_Load(sender, e);
                    return;
                }
                else
                {
                    int a = dbcon.execute_NonQuery("insert into Users values('" + txt_admin_QuanLyNhanVien_NhanVienInfo_MaNV.Text + "',N'" + txt_admin_QuanLyNhanVien_NhanVienInfo_TenNV.Text + "','" + txt_admin_QuanLyNhanVien_NhanVienInfo_SDT.Text + "',N'" + txt_admin_QuanLyNhanVien_NhanVienInfo_Address.Text + "','" + txt_admin_QuanLyNhanVien_NhanVienInfo_Password .Text+ "')");
                    if (a > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                        MessageBox.Show("Thêm không thành công!");

                    btn_admin_QuanLyNhanVien_ChucNang_SuaNhanVien.Enabled = true;
                    Quan_Ly_Load(sender, e);
                }
            }
        }

        private void txt_admin_QuanLyNhanVien_Search_TextChanged(object sender, EventArgs e)
        {
            LoadGridByKeyWord_NhanVien();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbcon.DS.Tables["tblSearch_San"].Clear();
            Load_gridview_San();

           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            LoadGridByKeyWord_San();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dbcon.DS.Tables["tblSearch_KhachHang"].Clear();
            Load_gridview_KhachHang();

           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            LoadGridByKeyWord_KhachHang();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dbcon.DS.Tables["tblSearch_HoaDon"].Clear();
            Load_gridview_HoaDon();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadGridByKeyWord_HoaDon();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
           
            textBox4.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == false)
            {
                DataRow dr = dbcon.DS.Tables["tblSan"].Rows.Find(textBox5.Text);
                if (dr != null)
                {
                    int a = dbcon.execute_NonQuery("update san set TenSan=N'"+textBox2.Text+"',MaLoai='"+comboBox1.SelectedValue.ToString()+"',GiaThue='"+textBox4.Text+"' where MaSan='"+textBox5.Text+"'");
                    if (a > 0)
                    {
                        MessageBox.Show("Sua Thanh Cong");
                    }
                    else
                        MessageBox.Show("Sua Ko Thanh Cong");
                    button2.Enabled = true;
                }
            }
            else
            {
                // kiểm tra khóa chính
                DataRow dr = dbcon.DS.Tables["tblSan"].Rows.Find(textBox5.Text);
                if (dr != null)
                {
                    MessageBox.Show("Trùng Mã Sân");
                    button4.Enabled = true;
                   
                    return;
                }
                else
                {
                    int a = dbcon.execute_NonQuery("insert into San Values('" + textBox5.Text.Trim() + "',N'" + textBox2.Text.Trim() + "','" + comboBox1.SelectedValue.ToString() + "','"+textBox4.Text+"')");
                    if (a > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                        MessageBox.Show("Thêm không thành công!");
                    Quan_Ly_Load(sender, e);
                    button4.Enabled = true;
                   
                }
            }
        }
        DataTable dt_khoa = new DataTable();
        private void Load_cboMaLoai()
        {
            dt_khoa.Clear();
            string sqlselect = "select * from LoaiSan";
            dt_khoa = dbcon.getDatatable(sqlselect, "LoaiSan");
            DataRow dr = dbcon.DS.Tables["LoaiSan"].NewRow();
            dr["MaLoai"] = -1;
            dr["TenLoaiSan"] = "No Selection"; // or "No Selection"

            dbcon.DS.Tables["LoaiSan"].Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt_khoa;
            comboBox1.DisplayMember = "TenLoaiSan";
            comboBox1.ValueMember = "MaLoai";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox9.Enabled = true;
            textBox7.Enabled=true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // kiểm tra khóa chính
            DataRow dr = dbcon.DS.Tables["tblKH"].Rows.Find(textBox7.Text);
            if (dr != null)
            {
                MessageBox.Show("Trùng SDT");            
                return;
            }
            else
            {
                int a = dbcon.execute_NonQuery("insert into KhachHang values('"+textBox7.Text+"',N'"+textBox9.Text+"')");
                if (a > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                }
                else
                    MessageBox.Show("Thêm không thành công!");
                Quan_Ly_Load(sender, e);
                
            }
        }

        private void tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Quan_Ly_Load(sender,e);
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        DataTable dt_DoanhSo = new DataTable();
        private void btn_admin_QuanLyDoanhThu_Xemketqua_Click(object sender, EventArgs e)
        {
            dt_DoanhSo.Clear();
            string sqlselect = "select convert (money,sum(TongTien))as'Tien' from DatSan ds,HoaDon hd where ds.MaDatSan=hd.MaDatSan and  NgayDat between '" + dateTimePicker_admin_start.Value.ToString("yyyy-MM-dd") + "' and  '" + dateTimePicker_admin_end.Value.ToString("yyyy-MM-dd") + "'";
            dt_DoanhSo = dbcon.getDatatable(sqlselect, "tblDoanhSo");
            lb_Tien_Time.Text = dt_DoanhSo.Rows[0]["Tien"].ToString();
        }
        public void load_cbo_San()
        {         
            string sqlselect = "select * from San";
            DataTable dt_kh = dbcon.getDatatable(sqlselect, "dbo.San");
            cbo_Tien_San.DataSource = dt_kh;
            cbo_Tien_San.DisplayMember = "TenSan";
            cbo_Tien_San.ValueMember = "MaSan";
        }
        public void load_cbo_KhachHang()
        {
            string sqlselect = "select * from Khachhang";
            DataTable dt_kh = dbcon.getDatatable(sqlselect, "dbo.KhachHang");
            cbo_Tien_KhachHang.DataSource = dt_kh;
            cbo_Tien_KhachHang.DisplayMember = "TenKhachHang";
            cbo_Tien_KhachHang.ValueMember = "SDT";
        }
        public void load_cbo_NhanVien()
        {
            string sqlselect = "select * from users";
            DataTable dt_kh = dbcon.getDatatable(sqlselect, "dbo.Users");
            cbo_tien_NhanVien.DataSource = dt_kh;
            cbo_tien_NhanVien.DisplayMember = "HoTen";
            cbo_tien_NhanVien.ValueMember = "Email";
        }

        DataTable dt_NhanVien = new DataTable();
        private void cbo_tien_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_NhanVien.Clear();
            string sqlselect = "EXEC SP_DoanhThuTheoEmail '"+cbo_tien_NhanVien.SelectedValue.ToString()+"'";
            dt_NhanVien = dbcon.execute_NonQuery_SP(sqlselect);
            if (dt_NhanVien.Rows.Count > 0)
            {
                lb_tien_NhanVien.Text = dt_NhanVien.Rows[0]["Tien"].ToString();
            }
            else
                lb_tien_NhanVien.Text = "0";
        }
        DataTable dt_San = new DataTable();
        private void cbo_Tien_San_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_San.Clear();
            string sqlselect = "EXEC SP_DoanhThuSan '"+cbo_Tien_San.SelectedValue.ToString()+"'";
            dt_San = dbcon.execute_NonQuery_SP(sqlselect);
            if (dt_San.Rows.Count > 0)
            {
                lb_Tien_San.Text = dt_San.Rows[0]["Tien"].ToString();
            }
            else
                lb_Tien_San.Text = "0";
        }
        DataTable dt_KhachHang = new DataTable();
        private void cbo_Tien_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_KhachHang.Clear();
            string sqlselect = "EXEC SP_DoanhThuKhachHang '"+cbo_Tien_KhachHang.SelectedValue.ToString()+"'";
            dt_KhachHang = dbcon.execute_NonQuery_SP(sqlselect);
            if (dt_KhachHang.Rows.Count > 0)
            {
                lb_TienKhachHang.Text = dt_KhachHang.Rows[0]["Tien"].ToString();
            }
            else
                lb_TienKhachHang.Text = "0"; 
        }
    }
}