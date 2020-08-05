namespace DACK_QLCH
{
    partial class frmTimKiemBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemBaoCao));
            this.label3 = new System.Windows.Forms.Label();
            this.gbKetQua = new System.Windows.Forms.GroupBox();
            this.dgTimKiemBC = new System.Windows.Forms.DataGridView();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.dtNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiemBC)).BeginInit();
            this.gbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(271, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "TÌM KIẾM BÁO CÁO";
            // 
            // gbKetQua
            // 
            this.gbKetQua.Controls.Add(this.dgTimKiemBC);
            this.gbKetQua.Location = new System.Drawing.Point(18, 195);
            this.gbKetQua.Name = "gbKetQua";
            this.gbKetQua.Size = new System.Drawing.Size(767, 229);
            this.gbKetQua.TabIndex = 9;
            this.gbKetQua.TabStop = false;
            this.gbKetQua.Text = "Kết Quả:";
            // 
            // dgTimKiemBC
            // 
            this.dgTimKiemBC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimKiemBC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma,
            this.Ten});
            this.dgTimKiemBC.Location = new System.Drawing.Point(16, 21);
            this.dgTimKiemBC.Name = "dgTimKiemBC";
            this.dgTimKiemBC.Size = new System.Drawing.Size(735, 182);
            this.dgTimKiemBC.TabIndex = 0;
            this.dgTimKiemBC.SelectionChanged += new System.EventHandler(this.dgTimKiemBC_SelectionChanged);
            // 
            // Ma
            // 
            this.Ma.HeaderText = "Mã:";
            this.Ma.Name = "Ma";
            // 
            // Ten
            // 
            this.Ten.HeaderText = "Tên";
            this.Ten.Name = "Ten";
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.btnThoat);
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Controls.Add(this.dtNgayLap);
            this.gbTimKiem.Controls.Add(this.txtSoHD);
            this.gbTimKiem.Controls.Add(this.label2);
            this.gbTimKiem.Controls.Add(this.label1);
            this.gbTimKiem.Location = new System.Drawing.Point(16, 77);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(750, 96);
            this.gbTimKiem.TabIndex = 8;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm Kiếm";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(625, 30);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 33);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(515, 30);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 33);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayLap.Location = new System.Drawing.Point(334, 35);
            this.dtNgayLap.Name = "dtNgayLap";
            this.dtNgayLap.Size = new System.Drawing.Size(138, 20);
            this.dtNgayLap.TabIndex = 7;
            this.dtNgayLap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtNgayLap_KeyPress);
            this.dtNgayLap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtNgayLap_MouseDown);
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(87, 34);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(182, 20);
            this.txtSoHD.TabIndex = 5;
            this.txtSoHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHD_KeyPress);
            this.txtSoHD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSoHD_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Lập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Hóa Đơn:";
            // 
            // frmTimKiemBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbKetQua);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "frmTimKiemBaoCao";
            this.Text = "Tìm Kiếm Báo Cáo";
            this.Load += new System.EventHandler(this.frmTimKiemBaoCao_Load);
            this.gbKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiemBC)).EndInit();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbKetQua;
        private System.Windows.Forms.DataGridView dgTimKiemBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtNgayLap;
    }
}