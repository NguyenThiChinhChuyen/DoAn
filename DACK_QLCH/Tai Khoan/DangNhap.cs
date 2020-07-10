using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DACK_QLCH.Moduls;

namespace DACK_QLCH
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap(frmMain pf)
        {
            fMain = pf;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn!", "QLCH", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                Application.Exit();
            }
            //Application.Exit();
        }

        private void frmDangNhap_Enter(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender,e);
        }

        private void frmDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
        frmMain fMain = null;
        XLNHANVIEN tblNhanVien;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            tblNhanVien = new XLNHANVIEN();
            DataRow[] r = tblNhanVien.Select("Username='" + txtDangNhap.Text + "' and Password='" + txtMatKhau.Text + "'");
            if (r.Count() > 0)
            {
                fMain.Text = "Quản lý Cửa Hàng  - Chào " + r[0]["HoTen"].ToString();
                fMain.maNV = r[0]["MaNV"].ToString();
                fMain.enableControl((int)r[0]["MaLTK"]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản và mật khẩu!!!");
            }
        }
    }
}
