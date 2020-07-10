using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DACK_QLCH.Moduls;

namespace DACK_QLCH
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
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

                    break;
                case 2://Nhan vien ban hang
                    btnDangXuat.Enabled = true;
                    btnDoiMatKhau.Enabled = true;

                    break;
                case 3://Nhan viên quản lý kho
                    btnDangXuat.Enabled = true;
                    btnDoiMatKhau.Enabled = true;

                    break;
                default://Đăng Xuất
                    btnDangXuat.Enabled = false;
                    btnDoiMatKhau.Enabled = false;
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
                //tabControlMain.SelectedTab = p;
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
    }
}
