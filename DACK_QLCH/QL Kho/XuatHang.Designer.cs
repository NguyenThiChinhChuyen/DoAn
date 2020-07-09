namespace DACK_QLCH
{
    partial class frmXuatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatHang));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgDSDXH = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateNgayPhieuXuat = new System.Windows.Forms.DateTimePicker();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLưu = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtNoiDungPX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoPX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoTenNV = new System.Windows.Forms.TextBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayPhieuXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDXH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "DANH SÁCH ĐƠN XUẤT HÀNG";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgDSDXH);
            this.groupBox2.Location = new System.Drawing.Point(24, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 265);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả:";
            // 
            // dgDSDXH
            // 
            this.dgDSDXH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSDXH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SoPhieuXuat,
            this.MaNhanVien,
            this.HoTen,
            this.NgayPhieuXuat,
            this.NoiDung});
            this.dgDSDXH.Location = new System.Drawing.Point(6, 21);
            this.dgDSDXH.Name = "dgDSDXH";
            this.dgDSDXH.Size = new System.Drawing.Size(834, 238);
            this.dgDSDXH.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateNgayPhieuXuat);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnLưu);
            this.groupBox1.Controls.Add(this.txtHoTenNV);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNoiDungPX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoPX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 136);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // dateNgayPhieuXuat
            // 
            this.dateNgayPhieuXuat.Location = new System.Drawing.Point(105, 53);
            this.dateNgayPhieuXuat.Name = "dateNgayPhieuXuat";
            this.dateNgayPhieuXuat.Size = new System.Drawing.Size(181, 20);
            this.dateNgayPhieuXuat.TabIndex = 8;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(736, 67);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 40);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(736, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 40);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Location = new System.Drawing.Point(634, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 40);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(634, 67);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 40);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(529, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 40);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            // 
            // btnLưu
            // 
            this.btnLưu.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLưu.Appearance.Options.UseFont = true;
            this.btnLưu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLưu.ImageOptions.Image")));
            this.btnLưu.Location = new System.Drawing.Point(529, 67);
            this.btnLưu.Name = "btnLưu";
            this.btnLưu.Size = new System.Drawing.Size(98, 40);
            this.btnLưu.TabIndex = 7;
            this.btnLưu.Text = "Lưu";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(366, 24);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(154, 20);
            this.txtMaNV.TabIndex = 5;
            // 
            // txtNoiDungPX
            // 
            this.txtNoiDungPX.Location = new System.Drawing.Point(73, 83);
            this.txtNoiDungPX.Multiline = true;
            this.txtNoiDungPX.Name = "txtNoiDungPX";
            this.txtNoiDungPX.Size = new System.Drawing.Size(447, 47);
            this.txtNoiDungPX.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mã Nhân Viên:";
            // 
            // txtSoPX
            // 
            this.txtSoPX.Location = new System.Drawing.Point(90, 24);
            this.txtSoPX.Name = "txtSoPX";
            this.txtSoPX.Size = new System.Drawing.Size(165, 20);
            this.txtSoPX.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Phiếu Xuất:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nội Dung:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Phiếu Xuất:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Location = new System.Drawing.Point(25, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(846, 55);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm Kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(31, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(322, 20);
            this.txtTimKiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.ImageOptions.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(366, 13);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 36);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm Kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Họ tên:";
            // 
            // txtHoTenNV
            // 
            this.txtHoTenNV.Location = new System.Drawing.Point(340, 54);
            this.txtHoTenNV.Name = "txtHoTenNV";
            this.txtHoTenNV.Size = new System.Drawing.Size(180, 20);
            this.txtHoTenNV.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // SoPhieuXuat
            // 
            this.SoPhieuXuat.HeaderText = "Số Phiếu Xuất";
            this.SoPhieuXuat.Name = "SoPhieuXuat";
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // NgayPhieuXuat
            // 
            this.NgayPhieuXuat.HeaderText = "Ngày Phiếu Xuất";
            this.NgayPhieuXuat.Name = "NgayPhieuXuat";
            this.NgayPhieuXuat.Width = 120;
            // 
            // NoiDung
            // 
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 300;
            // 
            // frmXuatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmXuatHang";
            this.Text = "DANH SÁCH ĐƠN XUẤT HÀNG";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDXH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgDSDXH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateNgayPhieuXuat;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnLưu;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtNoiDungPX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoPX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.TextBox txtHoTenNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayPhieuXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
    }
}