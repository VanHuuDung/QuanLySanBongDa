namespace Nhom06_Quan_Ly_San_Bong_Mini
{
    partial class Dat_San
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comb_San = new System.Windows.Forms.ComboBox();
            this.txt_MaDatSan = new System.Windows.Forms.TextBox();
            this.txt_thoigian = new System.Windows.Forms.TextBox();
            this.dtg_DatSan = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_ThemKhachHang = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_LuuSan = new System.Windows.Forms.Button();
            this.btn_xemdsSan = new System.Windows.Forms.Button();
            this.btn_HuySan = new System.Windows.Forms.Button();
            this.btn_DoiGio = new System.Windows.Forms.Button();
            this.btn_Datsan = new System.Windows.Forms.Button();
            this.dateTimePicker_Ra = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Ngay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_KhachHang = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dang_XuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Thong_TinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tai_KhoangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Thanh_ToanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nhan_SanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Danh_MucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker_Vao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_DatSan)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comb_San
            // 
            this.comb_San.FormattingEnabled = true;
            this.comb_San.Location = new System.Drawing.Point(27, 388);
            this.comb_San.Name = "comb_San";
            this.comb_San.Size = new System.Drawing.Size(342, 24);
            this.comb_San.TabIndex = 46;
            // 
            // txt_MaDatSan
            // 
            this.txt_MaDatSan.Location = new System.Drawing.Point(1024, 44);
            this.txt_MaDatSan.Name = "txt_MaDatSan";
            this.txt_MaDatSan.Size = new System.Drawing.Size(206, 22);
            this.txt_MaDatSan.TabIndex = 45;
            // 
            // txt_thoigian
            // 
            this.txt_thoigian.Location = new System.Drawing.Point(150, 206);
            this.txt_thoigian.Name = "txt_thoigian";
            this.txt_thoigian.Size = new System.Drawing.Size(206, 22);
            this.txt_thoigian.TabIndex = 44;
            // 
            // dtg_DatSan
            // 
            this.dtg_DatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_DatSan.Location = new System.Drawing.Point(452, 83);
            this.dtg_DatSan.Name = "dtg_DatSan";
            this.dtg_DatSan.RowTemplate.Height = 24;
            this.dtg_DatSan.Size = new System.Drawing.Size(778, 363);
            this.dtg_DatSan.TabIndex = 43;
            this.dtg_DatSan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_DatSan_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(459, 494);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Họ và tên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(459, 466);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Số điện thoại";
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(608, 494);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(199, 22);
            this.txt_hoten.TabIndex = 39;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(608, 466);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(199, 22);
            this.txt_sdt.TabIndex = 40;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.Location = new System.Drawing.Point(735, 540);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(72, 39);
            this.btn_Luu.TabIndex = 37;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_ThemKhachHang
            // 
            this.btn_ThemKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemKhachHang.Location = new System.Drawing.Point(463, 540);
            this.btn_ThemKhachHang.Name = "btn_ThemKhachHang";
            this.btn_ThemKhachHang.Size = new System.Drawing.Size(240, 39);
            this.btn_ThemKhachHang.TabIndex = 38;
            this.btn_ThemKhachHang.Text = "Thêm Khách Hàng";
            this.btn_ThemKhachHang.UseVisualStyleBackColor = true;
            this.btn_ThemKhachHang.Click += new System.EventHandler(this.btn_ThemKhachHang_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 29);
            this.label6.TabIndex = 36;
            this.label6.Text = "Đặt Sân";
            // 
            // btn_LuuSan
            // 
            this.btn_LuuSan.Location = new System.Drawing.Point(191, 329);
            this.btn_LuuSan.Name = "btn_LuuSan";
            this.btn_LuuSan.Size = new System.Drawing.Size(86, 39);
            this.btn_LuuSan.TabIndex = 34;
            this.btn_LuuSan.Text = "Lưu Sân";
            this.btn_LuuSan.UseVisualStyleBackColor = true;
            this.btn_LuuSan.Click += new System.EventHandler(this.btn_LuuSan_Click);
            // 
            // btn_xemdsSan
            // 
            this.btn_xemdsSan.Location = new System.Drawing.Point(1049, 452);
            this.btn_xemdsSan.Name = "btn_xemdsSan";
            this.btn_xemdsSan.Size = new System.Drawing.Size(181, 53);
            this.btn_xemdsSan.TabIndex = 35;
            this.btn_xemdsSan.Text = "Xem Danh Sách Sân";
            this.btn_xemdsSan.UseVisualStyleBackColor = true;
            this.btn_xemdsSan.Click += new System.EventHandler(this.btn_xemdsSan_Click);
            // 
            // btn_HuySan
            // 
            this.btn_HuySan.Location = new System.Drawing.Point(283, 329);
            this.btn_HuySan.Name = "btn_HuySan";
            this.btn_HuySan.Size = new System.Drawing.Size(86, 39);
            this.btn_HuySan.TabIndex = 33;
            this.btn_HuySan.Text = "Hủy Sân";
            this.btn_HuySan.UseVisualStyleBackColor = true;
            this.btn_HuySan.Click += new System.EventHandler(this.btn_HuySan_Click);
            // 
            // btn_DoiGio
            // 
            this.btn_DoiGio.Location = new System.Drawing.Point(105, 329);
            this.btn_DoiGio.Name = "btn_DoiGio";
            this.btn_DoiGio.Size = new System.Drawing.Size(80, 39);
            this.btn_DoiGio.TabIndex = 32;
            this.btn_DoiGio.Text = "Đổi Giờ";
            this.btn_DoiGio.UseVisualStyleBackColor = true;
            this.btn_DoiGio.Click += new System.EventHandler(this.btn_DoiGio_Click);
            // 
            // btn_Datsan
            // 
            this.btn_Datsan.Location = new System.Drawing.Point(27, 329);
            this.btn_Datsan.Name = "btn_Datsan";
            this.btn_Datsan.Size = new System.Drawing.Size(72, 39);
            this.btn_Datsan.TabIndex = 31;
            this.btn_Datsan.Text = "Đặt Sân";
            this.btn_Datsan.UseVisualStyleBackColor = true;
            this.btn_Datsan.Click += new System.EventHandler(this.btn_Datsan_Click);
            // 
            // dateTimePicker_Ra
            // 
            this.dateTimePicker_Ra.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_Ra.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_Ra.Location = new System.Drawing.Point(150, 253);
            this.dateTimePicker_Ra.Name = "dateTimePicker_Ra";
            this.dateTimePicker_Ra.Size = new System.Drawing.Size(206, 22);
            this.dateTimePicker_Ra.TabIndex = 30;
            this.dateTimePicker_Ra.Value = new System.DateTime(2022, 12, 24, 0, 0, 0, 0);
            // 
            // dateTimePicker_Ngay
            // 
            this.dateTimePicker_Ngay.CalendarMonthBackground = System.Drawing.SystemColors.WindowText;
            this.dateTimePicker_Ngay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_Ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Ngay.Location = new System.Drawing.Point(150, 123);
            this.dateTimePicker_Ngay.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_Ngay.MinDate = new System.DateTime(2000, 11, 9, 0, 0, 0, 0);
            this.dateTimePicker_Ngay.Name = "dateTimePicker_Ngay";
            this.dateTimePicker_Ngay.Size = new System.Drawing.Size(206, 22);
            this.dateTimePicker_Ngay.TabIndex = 29;
            this.dateTimePicker_Ngay.Value = new System.DateTime(2022, 12, 30, 21, 45, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Giờ Ra";
            // 
            // combo_KhachHang
            // 
            this.combo_KhachHang.FormattingEnabled = true;
            this.combo_KhachHang.Location = new System.Drawing.Point(150, 83);
            this.combo_KhachHang.Name = "combo_KhachHang";
            this.combo_KhachHang.Size = new System.Drawing.Size(206, 24);
            this.combo_KhachHang.TabIndex = 27;
            this.combo_KhachHang.SelectedIndexChanged += new System.EventHandler(this.combo_KhachHang_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(907, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Mã Đặt Sân";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Thời Gian";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Khách Hàng";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // Dang_XuatToolStripMenuItem
            // 
            this.Dang_XuatToolStripMenuItem.Name = "Dang_XuatToolStripMenuItem";
            this.Dang_XuatToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.Dang_XuatToolStripMenuItem.Text = "Đăng Xuất";
            this.Dang_XuatToolStripMenuItem.Click += new System.EventHandler(this.Dang_XuatToolStripMenuItem_Click);
            // 
            // Thong_TinToolStripMenuItem
            // 
            this.Thong_TinToolStripMenuItem.Name = "Thong_TinToolStripMenuItem";
            this.Thong_TinToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.Thong_TinToolStripMenuItem.Text = "Thông tin cá nhân";
            this.Thong_TinToolStripMenuItem.Click += new System.EventHandler(this.Thong_TinToolStripMenuItem_Click);
            // 
            // Tai_KhoangToolStripMenuItem
            // 
            this.Tai_KhoangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Thong_TinToolStripMenuItem,
            this.Dang_XuatToolStripMenuItem});
            this.Tai_KhoangToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Tai_KhoangToolStripMenuItem.Name = "Tai_KhoangToolStripMenuItem";
            this.Tai_KhoangToolStripMenuItem.Size = new System.Drawing.Size(96, 27);
            this.Tai_KhoangToolStripMenuItem.Text = "Tài Khoản";
            // 
            // Thanh_ToanToolStripMenuItem
            // 
            this.Thanh_ToanToolStripMenuItem.Name = "Thanh_ToanToolStripMenuItem";
            this.Thanh_ToanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.Thanh_ToanToolStripMenuItem.Size = new System.Drawing.Size(280, 28);
            this.Thanh_ToanToolStripMenuItem.Text = "Thanh Toán";
            this.Thanh_ToanToolStripMenuItem.Click += new System.EventHandler(this.Thanh_ToanToolStripMenuItem_Click);
            // 
            // Nhan_SanToolStripMenuItem
            // 
            this.Nhan_SanToolStripMenuItem.Name = "Nhan_SanToolStripMenuItem";
            this.Nhan_SanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Nhan_SanToolStripMenuItem.Size = new System.Drawing.Size(280, 28);
            this.Nhan_SanToolStripMenuItem.Text = "Nhận Sân";
            this.Nhan_SanToolStripMenuItem.Click += new System.EventHandler(this.Nhan_SanToolStripMenuItem_Click);
            // 
            // Danh_MucToolStripMenuItem
            // 
            this.Danh_MucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nhan_SanToolStripMenuItem,
            this.Thanh_ToanToolStripMenuItem});
            this.Danh_MucToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Danh_MucToolStripMenuItem.Name = "Danh_MucToolStripMenuItem";
            this.Danh_MucToolStripMenuItem.Size = new System.Drawing.Size(101, 27);
            this.Danh_MucToolStripMenuItem.Text = "Danh Mục";
            // 
            // dateTimePicker_Vao
            // 
            this.dateTimePicker_Vao.CalendarMonthBackground = System.Drawing.SystemColors.WindowText;
            this.dateTimePicker_Vao.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_Vao.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_Vao.Location = new System.Drawing.Point(150, 162);
            this.dateTimePicker_Vao.Name = "dateTimePicker_Vao";
            this.dateTimePicker_Vao.Size = new System.Drawing.Size(206, 22);
            this.dateTimePicker_Vao.TabIndex = 28;
            this.dateTimePicker_Vao.Value = new System.DateTime(2022, 12, 24, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Giờ Vào";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Danh_MucToolStripMenuItem,
            this.Tai_KhoangToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 31);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Dat_San
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1238, 595);
            this.Controls.Add(this.comb_San);
            this.Controls.Add(this.txt_MaDatSan);
            this.Controls.Add(this.txt_thoigian);
            this.Controls.Add(this.dtg_DatSan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_hoten);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_ThemKhachHang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_LuuSan);
            this.Controls.Add(this.btn_xemdsSan);
            this.Controls.Add(this.btn_HuySan);
            this.Controls.Add(this.btn_DoiGio);
            this.Controls.Add(this.btn_Datsan);
            this.Controls.Add(this.dateTimePicker_Ra);
            this.Controls.Add(this.dateTimePicker_Ngay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_KhachHang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_Vao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Dat_San";
            this.Text = "Trang_Chu";
            this.Load += new System.EventHandler(this.Dat_San_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_DatSan)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comb_San;
        private System.Windows.Forms.TextBox txt_MaDatSan;
        private System.Windows.Forms.TextBox txt_thoigian;
        private System.Windows.Forms.DataGridView dtg_DatSan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_ThemKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_LuuSan;
        private System.Windows.Forms.Button btn_xemdsSan;
        private System.Windows.Forms.Button btn_HuySan;
        private System.Windows.Forms.Button btn_DoiGio;
        private System.Windows.Forms.Button btn_Datsan;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ra;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_KhachHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dang_XuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Thong_TinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tai_KhoangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Thanh_ToanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Nhan_SanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Danh_MucToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Vao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;

    }
}