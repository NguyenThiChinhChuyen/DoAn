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
        string temp;
        public frmDoiMatKhau(string truyen)
        {
            InitializeComponent();
            this.temp = truyen;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassNew, "");
            errorProvider1.SetError(txtConfirmPass, "");
            if (txtPassNew.Text.Length<8 || !txtPassNew.Text.Any(char.IsDigit) || !txtPassNew.Text.Any(char.IsLower) || !txtPassNew.Text.Any(char.IsUpper))
            {
                errorProvider1.SetError(txtPassNew, "Mật khẩu mới tối thiểu 8 kí tự, gồm chữ số, " + "in hoa, in thường");
                return;
            }
            if (txtPassNew.Text != txtConfirmPass.Text)
            {
                errorProvider1.SetError(txtConfirmPass, "Mật khẩu nhập lại không trùng!!!");
                return;
            }
            frmMain f = (frmMain)this.MdiParent;
            MessageBox.Show(txtPassNew.Text.ToString() + temp);
            int count = XLBANG.Thuc_hien_lenh("Update NHANVIEN set Password='" + txtPassNew.Text + "' where MaNV='" + temp + "'");
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
