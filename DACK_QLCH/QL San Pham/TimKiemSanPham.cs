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

        private void frmTimKiemSanPham_Load(object sender, EventArgs e)
        {
            tblSanPham = new XLSANPHAM();
            loadTimKiem();
            
        }
        private void loadTimKiem()
        {
            dgTimKiemSP.AutoGenerateColumns = false;
            dgTimKiemSP.DataSource = tblSanPham;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (radMaSP.Checked == true)
            {
                string std = string.Format("MaSP like '%{0}%'", txtTimKiem.Text);
                tblSanPham.DefaultView.RowFilter = std;
            }
            else
            {
                string std = string.Format("TenSP like '%{0}%'", txtTimKiem.Text);
                tblSanPham.DefaultView.RowFilter = std;
            }
        }

        private void dgTimKiemSP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemSP.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }
    }
}
