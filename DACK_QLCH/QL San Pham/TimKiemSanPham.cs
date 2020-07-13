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
    public partial class frmTimKiemSanPham : Form
    {
        public frmTimKiemSanPham()
        {
            InitializeComponent();
        }
        XLSANPHAM tblSanPham;
        BindingManagerBase DSTKSP;

        private void frmTimKiemSanPham_Load(object sender, EventArgs e)
        {
            tblSanPham = new XLSANPHAM();
            DSTKSP = this.BindingContext[tblSanPham];
            loadTimKiem();
            
        }
        private void loadTimKiem()
        {
            txtMaSP.DataBindings.Add("text", tblSanPham, "MaSP", true);
            txtTenSP.DataBindings.Add("text", tblSanPham, "TenSP", true);
            dgTimKiemSP.AutoGenerateColumns = false;
            dgTimKiemSP.DataSource = tblSanPham;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void dgTimKiemSP_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemSP.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblSanPham.Select("MaSP='" + txtMaSP.Text + "' and TenSP='" + txtTenSP.Text + "'")[1];
                DSTKSP.Position = tblSanPham.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void txtMaSP_MouseDown(object sender, MouseEventArgs e)
        {
            txtMaSP.Text = "";
        }

        private void txtMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void txtTenSP_MouseDown(object sender, MouseEventArgs e)
        {
            txtTenSP.Text = "";
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }
    }
}
