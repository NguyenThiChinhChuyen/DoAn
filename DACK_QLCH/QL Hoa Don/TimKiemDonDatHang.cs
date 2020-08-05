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
    public partial class frmTimKiemDonDatHang : Form
    {
        public frmTimKiemDonDatHang()
        {
            InitializeComponent();
        }
        XLHOADONDH_CT tblHoaDonDH_CT;
        XLSANPHAM tblSanPham;
        BindingManagerBase DGTKDH;

        bool capNhat = false;
        private void frmTimKiemDonDatHang_Load(object sender, EventArgs e)
        {
            tblHoaDonDH_CT = new XLHOADONDH_CT();
            tblSanPham = new XLSANPHAM();
            tinhtien();
            LoadHD();
            enable();
        }
        private void enable()
        {
            txtThanhTien.Enabled = capNhat;
        }
        private void tinhtien()
        {

            for (int r = 0; r < dgDSDDH.Rows.Count; r++)
            {
                dgDSDDH.Rows[r].Cells[12].Value = Convert.ToInt32(dgDSDDH.Rows[r].Cells[10].Value) * Convert.ToInt32(dgDSDDH.Rows[r].Cells[11].Value);
               
            }
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
            txtThanhTien.DataBindings.Add("text", tblHoaDonDH_CT, "ThanhTien", true);
            DGTKDH = this.BindingContext[tblHoaDonDH_CT];
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDonDH_CT;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();

        }
        private void dgDSDDH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDDH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
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
        }
    }
}
