using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DACK_QLCH.Moduls;
using DACK_QLCH.QL_Hoa_Don;
using DACK_QLCH.QL_Hoa_Don.Report.Hoa_Don_Dat;
using DACK_QLCH.QL_Nha_Cung_Cap;
using DACK_QLCH.QL_San_Pham;
using DACK_QLCH.Report;

namespace DACK_QLCH
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public string maNV;

        public void enableControl(int maLTK)
        {
            switch (maLTK)
            {
                case 1://admin
                    btnDangXuat.Enabled = true;
                    btnDoiMatKhau.Enabled = true;
                    btnDonDatHang.Enabled = true;
                    btnHoaDonBan.Enabled = true;
                    btnInHDDAT.Enabled = true;
                    btnInHoaDonBan.Enabled = true;
                    btnNhaCungCap.Enabled = true;
                    btnSanPham.Enabled = true;
                    btnNhapHang.Enabled = true;
                    btnXuatHang.Enabled = true;

                    break;
                case 3://Nhan vien ban hang
                    btnDangXuat.Enabled = true;
                    btnDoiMatKhau.Enabled = false;
                    btnDonDatHang.Enabled = true;
                    btnHoaDonBan.Enabled = true;
                    btnNhaCungCap.Enabled = false;
                    btnSanPham.Enabled = true;
                    btnInHDDAT.Enabled = true;
                    btnInHoaDonBan.Enabled = true;
                    btnNhapHang.Enabled = false;
                    btnXuatHang.Enabled = false;

                    break;
                case 2://Nhan viên quản lý kho
                    btnDangXuat.Enabled = true;
                    btnDoiMatKhau.Enabled = false;
                    btnDonDatHang.Enabled = false;
                    btnHoaDonBan.Enabled = false;
                    btnNhaCungCap.Enabled = false;
                    btnSanPham.Enabled = true;
                    btnInHDDAT.Enabled = false;
                    btnInHoaDonBan.Enabled = false;
                    btnNhapHang.Enabled = true;
                    btnXuatHang.Enabled = true;

                    break;
                default://Đăng Xuất
                    btnInHDDAT.Enabled = false;
                    btnInHoaDonBan.Enabled = false;
                    btnDangXuat.Enabled = false;
                    btnDoiMatKhau.Enabled = false;
                    btnDonDatHang.Enabled = false;
                    btnHoaDonBan.Enabled = false;
                    btnNhaCungCap.Enabled = false;
                    btnSanPham.Enabled = false;
                    btnNhapHang.Enabled = false;
                    btnXuatHang.Enabled = false;
                    break;
            }
        }
        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabControlMain.TabPages.Clear();
            frmMain_Load(sender, e);
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageDoiMatKhau");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmDoiMatKhau f = new frmDoiMatKhau(maNV);
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageDoiMatKhau";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            enableControl(-1);
            frmDangNhap f = new frmDangNhap(this);
            f.StartPosition = FormStartPosition.CenterScreen;
            //f.Show();
            f.WindowState = FormWindowState.Normal;
            f.ShowDialog();
            //tabControl1.Hide();
        }
        private void btnSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageSanPham");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
              
                frmSanPham f= new frmSanPham();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageSanPham";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }
        private void btnNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageNhapHang");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmNhapHang f = new frmNhapHang();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageNhapHang";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnDonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageDonDatHang");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmDonDatHang f = new frmDonDatHang();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageDonDatHang";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }
        private void btnHoaDonBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageHoaDonBan");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmHoaDonBan f = new frmHoaDonBan();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageHoaDonBan";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemSanPham");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemSanPham f = new frmTimKiemSanPham();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemSanPham";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemHDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemDonDaLap");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemDonDaLap f = new frmTimKiemDonDaLap();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemDonDaLap";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemDNH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemHangNhap");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemNhapHang f = new frmTimKiemNhapHang();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemHangNhap";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemDonDatHang");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemDonDatHang f = new frmTimKiemDonDatHang();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemDonDatHang";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageNhaCungCap");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmNhaCungCap f = new frmNhaCungCap();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageNhaCungCap";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemNhaCungCap");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemNhaCungCap f = new frmTimKiemNhaCungCap();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemNhaCungCap";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnTimKiemBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageTimKiemBaoCao");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmTimKiemBaoCao f = new frmTimKiemBaoCao();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageTimKiemBaoCao";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }
        private void btnInHDDAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageInHoaDnDat");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmHDDat f = new frmHDDat();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageInHoaDonDat";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }

        private void btnInHoaDonBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabControlMain.TabPages.IndexOfKey("tabPageInHoaDonBan");
            if (index > 0)
                tabControlMain.SelectedIndex = index;
            else
            {
                frmInHDBH f = new frmInHDBH();
                TabPage p = new TabPage(f.Text);
                p.Name = "tabPageInHoaDonBan";
                f.TopLevel = false;
                p.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                tabControlMain.TabPages.Add(p);
                tabControlMain.SelectedTab = p;
                f.Show();
            }
        }
    }
}
