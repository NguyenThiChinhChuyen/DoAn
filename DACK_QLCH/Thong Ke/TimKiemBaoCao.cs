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

namespace DACK_QLCH
{
    public partial class frmTimKiemBaoCao : Form
    {
        public frmTimKiemBaoCao()
        {
            InitializeComponent();
        }
        XLNCC tblNhaCC;
        BindingManagerBase DSNCC;

        private void frmTimKiemBaoCao_Load(object sender, EventArgs e)
        {
            tblNhaCC = new XLNCC();
            DSNCC = this.BindingContext[tblNhaCC];
            loadTimKiem();
        }

        private void loadTimKiem()
        {
            dgTimKiemBC.AutoGenerateColumns = false;
            dgTimKiemBC.DataSource = tblNhaCC;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void dgTimKiemBC_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemBC.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblNhaCC.Select("So Hoa Don='" + txtSoHD.Text + "' and Ngay Lap='" + dtNgayLap.Text + "'")[0];
                DSNCC.Position = tblNhaCC.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void txtSoHD_MouseDown(object sender, MouseEventArgs e)
        {
            txtSoHD.Text = " ";
        }

        private void dtNgayLap_MouseDown(object sender, MouseEventArgs e)
        {
            dtNgayLap.Text = " ";
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void dtNgayLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }
    }
}
