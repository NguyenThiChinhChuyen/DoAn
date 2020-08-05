using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DACK_QLCH.Moduls;
using DevExpress.Utils.Extensions;

namespace DACK_QLCH
{
    public partial class frmTimKiemNhaCungCap : Form
    {
        public frmTimKiemNhaCungCap()
        {
            InitializeComponent();
        }
        XLNCC tblNCC;
        BindingManagerBase DSNCC;

        private void frmTimKiemNhaCungCap_Load(object sender, EventArgs e)
        {
            tblNCC = new XLNCC();
            DSNCC = this.BindingContext[tblNCC];
            loadTimKiem();
        }

        private void loadTimKiem()
        {
            dgDSNCC.AutoGenerateColumns = false;
            dgDSNCC.DataSource = tblNCC;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void dgDSNCC_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgDSNCC.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblNCC.Select("MaNCC='" + txtMaNCC.Text + "' and TenNCC='" + txtTenNCC.Text + "'")[0];
                DSNCC.Position = tblNCC.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void txtMaNCC_MouseDown(object sender, MouseEventArgs e)
        {
            txtMaNCC.Text = "";
        }

        private void txtTenNCC_MouseDown(object sender, MouseEventArgs e)
        {
            txtTenNCC.Text = "";
        }

        private void txtMaNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void txtTenNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }
    }
}
