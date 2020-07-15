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
        XLHOADON tblHoaDon;
        XLHOADON_CT tblHOADON_CT;
        BindingManagerBase DGTKDH;

        private void frmTimKiemDonDatHang_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblHOADON_CT = new XLHOADON_CT();
            DGTKDH = this.BindingContext[tblHoaDon];
            LoadHoaDon_CTdgDONDATHANG();
        }
        private void LoadHoaDon_CTdgDONDATHANG()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHOADON_CT, tblHoaDon });
            ds.Relations.Add(new DataRelation("FRK_HOADON_CT_HOADON", tblHOADON_CT.Columns["SoHD"], tblHoaDon.Columns["SoHD"]));
            DataColumn cot_SoLuong = new DataColumn("SoLuong", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).SoLuong");
            tblHoaDon.Columns.Add(cot_SoLuong);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).DonGia");
            tblHoaDon.Columns.Add(cot_DonGia);
            DataColumn cot_ThanhTien = new DataColumn("ThanhTien", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).ThanhTien");
            tblHoaDon.Columns.Add(cot_ThanhTien);
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDon;
        }

        private void dgDSDDH_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDDH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblHoaDon.Select("MaSP='" + txtSoHD.Text + "' and NgayGH='" + dateNgayLap.Text + "'")[0];
                DGTKDH.Position = tblHoaDon.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();

        }

        private void txtSoHD_MouseDown(object sender, MouseEventArgs e)
        {
            txtSoHD.Text = "";
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void dateNgayLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void dateNgayLap_MouseDown(object sender, MouseEventArgs e)
        {
            dateNgayLap.Text = "";
        }
    }
}
