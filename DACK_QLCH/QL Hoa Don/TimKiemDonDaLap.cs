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
        XLHOADON_CT tblHoaDon_CT;
        BindingManagerBase DGTKDDL;
        
        private void TimKiemDonDaLap_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblHoaDon_CT = new XLHOADON_CT();
            loadHoaDon();
            LoadHoaDon();
            DGTKDDL = this.BindingContext[tblHoaDon];
        }
        private void LoadHoaDon()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHoaDon_CT, tblHoaDon });
            ds.Relations.Add(new DataRelation("FRK_HOADON_CT_HOADON", tblHoaDon_CT.Columns["SoHD"], tblHoaDon.Columns["SoHD"]));
            DataColumn cot_SoLuong = new DataColumn("SoLuong", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).SoLuong");
            tblHoaDon.Columns.Add(cot_SoLuong);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).DonGia");
            tblHoaDon.Columns.Add(cot_DonGia);
            DataColumn cot_ThanhTien = new DataColumn("ThanhTien", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).ThanhTien");
            tblHoaDon.Columns.Add(cot_ThanhTien);
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
