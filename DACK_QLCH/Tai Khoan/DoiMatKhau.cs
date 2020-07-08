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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMKM, "");
            errorProvider1.SetError(txtMKC, "");
            if (txtMKM.Text.Length < 8 || txtMKM.Text.Any(char.IsDigit) || !txtMKM.Text.Any(char.IsLower) || !txtMKM.Text.Any(char.IsUpper))
            {
                errorProvider1.SetError(txtMKM, "Mật khẩu mới tối thiểu 8 kí tự, gồm chữ số, " + "in hoa, in thường");
                return;
            }
            if (txtMKM.Text != txtMKC.Text)
            {
                errorProvider1.SetError(txtMKC, "Mật khẩu nhập lại không trùng!!!");
                return;
            }
            frmMain f = (frmMain)this.MdiParent;
            int count = XLBANG.Thuc_hien_lenh("Update NHANVIEN set Password= '" + txtMKM.Text + "' where MaNV='" + f.maNV + "'");
            if (count > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Mật khẩu không hợp lệ!!!");
            }
        }

    }
}
