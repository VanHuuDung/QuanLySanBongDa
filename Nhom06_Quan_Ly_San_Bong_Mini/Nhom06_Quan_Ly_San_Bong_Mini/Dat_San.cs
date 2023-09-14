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
    public partial class Dat_San : Form
    {
        DBConnect dbconn = new DBConnect();
        DataTable dt_san = new DataTable();
        DataTable dt_kh = new DataTable();

        private string email;


        public Dat_San()
        {
            InitializeComponent();
            dateTimePicker_Vao.ShowUpDown = true;
            dateTimePicker_Ra.ShowUpDown = true;
        }
        public Dat_San(string Email)
            : this()
        {
            email = Email;
        }
        void btn_Click(object sender, EventArgs e)
        {
            string SanID = ((sender as Button).Tag as San).ID;
        }
        public void load_combobox_khachhang()
        {
            dt_kh.Clear();
            string sqlselect = "select * from Khachhang";
            dt_kh = dbconn.getDatatable(sqlselect, "dbo.KhachHang");
            combo_KhachHang.DataSource = dt_kh;
            combo_KhachHang.DisplayMember = "TenKhachHang";
            combo_KhachHang.ValueMember = "SDT";
        }
        public void Load_combobox_San()
        {

            dt_san.Clear();
            string sqlselect = "select * from San where MaSan NOT IN (select San.MaSan from San, DatSan, KhachHang where San.MaSan = DatSan.MaSan and DatSan.SDTKhachHang = KhachHang.SDT and NgayDat = '" + dateTimePicker_Ngay.Value.ToString("yyyy-MM-dd") + "' and ((TGVao between '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "') or (TGRa between '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "')or (TGVao < '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and TGRa > '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "')))";

            dt_san = dbconn.getDatatable(sqlselect, "dbo.San");
            comb_San.DataSource = dt_san;
            comb_San.DisplayMember = "TenSan";
            comb_San.ValueMember = "MaSan";
        }

        private void Dat_San_Load(object sender, EventArgs e)
        {
            load_combobox_khachhang();

            combo_KhachHang.Enabled = false;
            dateTimePicker_Ngay.Enabled = dateTimePicker_Ra.Enabled = dateTimePicker_Vao.Enabled = false;
            btn_LuuSan.Enabled = btn_Luu.Enabled = false;
            txt_thoigian.Enabled = txt_hoten.Enabled = txt_sdt.Enabled = false;
        }

        private void Thong_TinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thong_Tin_Ca_Nhan tt = new Thong_Tin_Ca_Nhan(email);
            tt.ShowDialog();
        }

        DataTable dt_datsan = new DataTable();
        public void loaddulieu()
        {
            dt_datsan.Clear();
            string func = "select * from F_TraVeSanDaDat_Trung('" + dateTimePicker_Ngay.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "','" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "')";
            //string sqlselect = "select DatSan.*, KhachHang.TenKhachHang from DatSan, KhachHang where DatSan.SDTKhachHang = KhachHang.SDT and NgayDat = '" + dateTimePicker_Ngay.Value.ToString("yyyy-MM-dd") + "' and ((TGVao between '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "') or (TGRa between '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "') or (TGVao < '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "' and TGRa > '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "'))";
            dt_datsan = dbconn.getDatatable(func, "dbo.DatSan");
            dtg_DatSan.DataSource = dt_datsan;
        }

        private void dtg_DatSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txt_MaDatSan.Text = dtg_DatSan.Rows[numrow].Cells[0].Value.ToString().Trim();
            combo_KhachHang.Text = dtg_DatSan.Rows[numrow].Cells[6].Value.ToString().Trim();
            dateTimePicker_Ngay.Text = dtg_DatSan.Rows[numrow].Cells[3].Value.ToString().Trim();
            dateTimePicker_Vao.Text = dtg_DatSan.Rows[numrow].Cells[4].Value.ToString().Trim();
            dateTimePicker_Ra.Text = dtg_DatSan.Rows[numrow].Cells[5].Value.ToString().Trim();
            TimeSpan time = Convert.ToDateTime(dateTimePicker_Ra.Text) - Convert.ToDateTime(dateTimePicker_Vao.Text);
            txt_thoigian.Text = time.ToString();
            btn_HuySan.Enabled = true;
        }

        public bool KT_trung_sdt(string sdt)
        {
            dbconn.openConnecttion();
            string selectstring = "select * from KhachHang where SDT = '" + sdt + "'";
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
        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            txt_hoten.ResetText();
            txt_sdt.ResetText();
            btn_Luu.Enabled = txt_sdt.Enabled = txt_hoten.Enabled = true;
            btn_ThemKhachHang.Enabled = false;
            btn_Datsan.Enabled = true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sdt = txt_sdt.Text;
            string hoten = txt_hoten.Text;
            try
            {
                if (KT_trung_sdt(sdt) == false)
                {
                    string insertString = "insert into KhachHang values('" + sdt + "', N'" + hoten + "')";
                    int kq = dbconn.execute_NonQuery(insertString);
                    if (kq > 0)
                    {
                        MessageBox.Show("Đăng ký thành công");
                        Dat_San_Load(sender, e);
                    }

                }
                else
                {
                    MessageBox.Show("SDT đã được đăng ký");
                }
            }
            catch
            {
                MessageBox.Show("Đăng ký không thành công");
            }
        }



        private void Nhan_SanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhan_San a = new Nhan_San();
            a.ShowDialog();
        }

        private void Thanh_ToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thanh_Toan a = new Thanh_Toan(email);
            a.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (email == "admin@gmail.com")
            {
                Quan_Ly a = new Quan_Ly();
                a.ShowDialog();
            }
            else
                MessageBox.Show("Bạn không có quyền truy cập");
        }

        private void Dang_XuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dang_Nhap a = new Dang_Nhap();
            this.Hide();
            a.ShowDialog();
        }

        private void btn_xemdsSan_Click(object sender, EventArgs e)
        {
            loaddulieu();
            Load_combobox_San();
        }

        private void btn_LuuSan_Click(object sender, EventArgs e)
        {
            if (combo_KhachHang.Enabled == true)
            {
                try
                {
                    string insertString = "insert into DatSan values ('" + combo_KhachHang.SelectedValue.ToString() + "', '" + comb_San.SelectedValue.ToString() + "', '" + dateTimePicker_Ngay.Value.ToString("yyyy-MM-dd") + "', '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "', '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "')";
                    int kq = dbconn.execute_NonQuery(insertString);
                    if (kq > 0)
                        MessageBox.Show("Đặt sân thành công");
                }
                catch
                {
                    MessageBox.Show("Đặt sân không thành công");
                }
            }
            else
            {
                try
                {

                    string insertString = "update DatSan set MaSan = '" + comb_San.SelectedValue.ToString() + "', NgayDat = '" + dateTimePicker_Ngay.Value.ToString("yyyy-MM-dd") + "', TGVao = '" + dateTimePicker_Vao.Value.ToString("HH:mm:ss") + "', TGRa = '" + dateTimePicker_Ra.Value.ToString("HH:mm:ss") + "' where MaDatSan = '" + txt_MaDatSan.Text + "'";
                    int kq = dbconn.execute_NonQuery(insertString);
                    if (kq > 0)
                        MessageBox.Show("Đổi sân thành công");
                }
                catch
                {
                    MessageBox.Show("Đổi sân không thành công");
                }
            }
            btn_Datsan.Enabled = btn_DoiGio.Enabled = true;
            btn_LuuSan.Enabled = false;
        }

        private void btn_DoiGio_Click(object sender, EventArgs e)
        {
            combo_KhachHang.Enabled = false;
            dateTimePicker_Ra.Enabled = dateTimePicker_Ngay.Enabled = dateTimePicker_Vao.Enabled = true;
            btn_LuuSan.Enabled = true;
            btn_DoiGio.Enabled = false;
        }

        private void btn_Datsan_Click(object sender, EventArgs e)
        {
            combo_KhachHang.Enabled = true;
            dateTimePicker_Ra.Enabled = dateTimePicker_Ngay.Enabled = dateTimePicker_Vao.Enabled = true;
            btn_LuuSan.Enabled = true;
            btn_Datsan.Enabled = false;
        }

        private void btn_HuySan_Click(object sender, EventArgs e)
        {
            try
            {
                string insertString = "delete from DatSan where MaDatSan = '" + txt_MaDatSan.Text + "'";
                int kq = dbconn.execute_NonQuery(insertString);
                if (kq > 0)
                    MessageBox.Show("Hủy sân thành công");
            }
            catch
            {
                MessageBox.Show("Huy sân không thành công");
            }
        }

        private void combo_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
