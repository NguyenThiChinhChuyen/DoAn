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
using DACK_QLCH.Report;

namespace DACK_QLCH.QL_Hoa_Don.Report.Hoa_Don_Dat
{
    public partial class frmHDDat : Form
    {
        public frmHDDat()
        {
            InitializeComponent();
        }
        XLHOADONDH_CT tblHoaDonDH_CT;
        XLSANPHAM tblSanPham;
        BindingManagerBase DGTKDH;
       bool capNhat = false;

        private void frmHDDat_Load(object sender, EventArgs e)
        {
            tblHoaDonDH_CT = new XLHOADONDH_CT();
            tblSanPham = new XLSANPHAM();
            
            LoadHD();
            enable();
        }
        private void enable()
        {
            txtsohoadon.Enabled = capNhat;
            txtTenKH.Enabled = capNhat;
        }
        private void LoadHD()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHoaDonDH_CT, tblSanPham });
            DataRelation qh = new DataRelation("FPK_SANPHAM_HOADONDH_CT", tblSanPham.Columns["MaSP"], tblHoaDonDH_CT.Columns["MaSP"]);
            ds.Relations.Add(qh);
            DataColumn cot_TenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADONDH_CT).TenSP");
            tblHoaDonDH_CT.Columns.Add(cot_TenSP);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADONDH_CT).DonGia");
            tblHoaDonDH_CT.Columns.Add(cot_DonGia);
            txtsohoadon.DataBindings.Add("text", tblHoaDonDH_CT, "SoHDDH", true);
            txtTenKH.DataBindings.Add("text", tblHoaDonDH_CT, "TenKHGH", true);
            DGTKDH = this.BindingContext[tblHoaDonDH_CT];
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDonDH_CT;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInHDDAT f = new frmInHDDAT();
            f.SoHDDH = txtsohoadon.Text;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (radSoHD.Checked == true)
            {
                string std = string.Format("SoHDDH like '%{0}%'", txtTimKiem.Text);
                tblHoaDonDH_CT.DefaultView.RowFilter = std;
            }
            else
            {
                string std = string.Format("TenKHGH like '%{0}%'", txtTimKiem.Text);
                tblHoaDonDH_CT.DefaultView.RowFilter = std;
            }
        }

        private void dgDSDDH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDDH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }
    }
}
