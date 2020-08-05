namespace DACK_QLCH.Report
{
    partial class frmInHDBH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInHDBH));
            this.radMaNCC = new System.Windows.Forms.RadioButton();
            this.radSoHD = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsohoadonct = new System.Windows.Forms.TextBox();
            this.txtsohoadon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgTimKiemDDL = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiemDDL)).BeginInit();
            this.SuspendLayout();
            // 
            // radMaNCC
            // 
            this.radMaNCC.AutoSize = true;
            this.radMaNCC.Location = new System.Drawing.Point(516, 138);
            this.radMaNCC.Name = "radMaNCC";
            this.radMaNCC.Size = new System.Drawing.Size(84, 17);
            this.radMaNCC.TabIndex = 40;
            this.radMaNCC.Text = "Số Hóa Đơn";
            this.radMaNCC.UseVisualStyleBackColor = true;
            // 
            // radSoHD
            // 
            this.radSoHD.AutoSize = true;
            this.radSoHD.Checked = true;
            this.radSoHD.Location = new System.Drawing.Point(407, 138);
            this.radSoHD.Name = "radSoHD";
            this.radSoHD.Size = new System.Drawing.Size(96, 17);
            this.radSoHD.TabIndex = 41;
            this.radSoHD.TabStop = true;
            this.radSoHD.Text = "Số HD Chi Tiết";
            this.radSoHD.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(237, 137);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(141, 20);
            this.txtTimKiem.TabIndex = 39;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tìm Kiếm:";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(692, 116);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 40);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "IN HÓA ĐƠN BÁN HÀNG";
            // 
            // txtsohoadonct
            // 
            this.txtsohoadonct.Location = new System.Drawing.Point(475, 93);
            this.txtsohoadonct.Name = "txtsohoadonct";
            this.txtsohoadonct.Size = new System.Drawing.Size(100, 20);
            this.txtsohoadonct.TabIndex = 46;
            // 
            // txtsohoadon
            // 
            this.txtsohoadon.Location = new System.Drawing.Point(237, 93);
            this.txtsohoadon.Name = "txtsohoadon";
            this.txtsohoadon.Size = new System.Drawing.Size(100, 20);
            this.txtsohoadon.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Số Hóa Đơn CT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Số Hóa Đơn :";
            // 
            // dgTimKiemDDL
            // 
            this.dgTimKiemDDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimKiemDDL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SoHDCT,
            this.SoHD,
            this.MaNV,
            this.MaKH,
            this.MaSP,
            this.TenSP,
            this.NgayHD,
            this.SoLuong,
            this.DonGia,
            this.ThanhTien});
            this.dgTimKiemDDL.Location = new System.Drawing.Point(61, 184);
            this.dgTimKiemDDL.Name = "dgTimKiemDDL";
            this.dgTimKiemDDL.Size = new System.Drawing.Size(793, 356);
            this.dgTimKiemDDL.TabIndex = 47;
            this.dgTimKiemDDL.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgTimKiemDDL_DataBindingComplete);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // SoHDCT
            // 
            this.SoHDCT.DataPropertyName = "SoHDCT";
            this.SoHDCT.HeaderText = "Số Hóa Đơn Chi Tiết";
            this.SoHDCT.Name = "SoHDCT";
            // 
            // SoHD
            // 
            this.SoHD.DataPropertyName = "SoHD";
            this.SoHD.HeaderText = "Số Hóa Đơn";
            this.SoHD.Name = "SoHD";
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã Nhân Viên";
            this.MaNV.Name = "MaNV";
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã Khách Hàng";
            this.MaKH.Name = "MaKH";
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã Sản Phẩm";
            this.MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.Name = "TenSP";
            // 
            // NgayHD
            // 
            this.NgayHD.DataPropertyName = "NgayHD";
            this.NgayHD.HeaderText = "Ngày Lập";
            this.NgayHD.Name = "NgayHD";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnIn.Location = new System.Drawing.Point(692, 69);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(98, 40);
            this.btnIn.TabIndex = 34;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmInHDBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 550);
            this.Controls.Add(this.dgTimKiemDDL);
            this.Controls.Add(this.txtsohoadonct);
            this.Controls.Add(this.txtsohoadon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radMaNCC);
            this.Controls.Add(this.radSoHD);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnThoat);
            this.Name = "frmInHDBH";
            this.Text = "In Hóa Đơn";
            this.Load += new System.EventHandler(this.frmInHDBH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiemDDL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radMaNCC;
        private System.Windows.Forms.RadioButton radSoHD;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsohoadonct;
        private System.Windows.Forms.TextBox txtsohoadon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgTimKiemDDL;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private DevExpress.XtraEditors.SimpleButton btnIn;
    }
}