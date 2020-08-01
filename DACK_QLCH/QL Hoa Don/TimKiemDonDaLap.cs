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
    public partial class frmTimKiemDonDaLap : Form
    {
        public frmTimKiemDonDaLap()
        {
            InitializeComponent();
        }
        XLHOADON tblHoaDon;
        XLSANPHAM tblSanPham;
        BindingManagerBase DGTKDDL;
        
        private void TimKiemDonDaLap_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblSanPham = new XLSANPHAM();
            loadHoaDon();
            LoadHoaDon();
            DGTKDDL = this.BindingContext[tblHoaDon];
        }
        private void LoadHoaDon()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblSanPham, tblHoaDon});
            ds.Relations.Add(new DataRelation("FRK_SANPHAM_HOADON", tblSanPham.Columns["MaSP"], tblHoaDon.Columns["MaSP"]));
            DataColumn cot_TenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FRK_SANPHAM_HOADON).TenSP");
            tblHoaDon.Columns.Add(cot_TenSP);

        }
        private void loadHoaDon()
        {
            dgTimKiemDDL.AutoGenerateColumns = false;
            dgTimKiemDDL.DataSource = tblHoaDon;
        }
        private void dgTimKiemDDL_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemDDL.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblHoaDon.Select("MaSP='" + txtSoHD.Text + "' and NgayHD='" + dateNgayLap.Text + "'")[0];
                DGTKDDL.Position = tblHoaDon.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void txtSoHD_MouseDown(object sender, MouseEventArgs e)
        {
            txtSoHD.Text = "";
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void dateNgayLap_KeyDown(object sender, KeyEventArgs e)
        {

            btnTimKiem_Click(sender, e);
        }

        private void dateNgayLap_MouseDown(object sender, MouseEventArgs e)
        {
            dateNgayLap.Text = "";
        }
    }
}
