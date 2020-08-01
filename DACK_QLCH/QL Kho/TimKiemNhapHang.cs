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
using DevExpress.XtraEditors.Filtering.Templates;

namespace DACK_QLCH
{
    public partial class frmTimKiemNhapHang : Form
    {
        public frmTimKiemNhapHang()
        {
            InitializeComponent();
        }
        XLPHIEUNHAP tblPhieuNhap;
        XLPHIEUNHAP_CT tblPhieuNhap_CT;
        BindingManagerBase DSTKHN;

        private void frmTimKiemNhapHang_Load(object sender, EventArgs e)
        {
            tblPhieuNhap = new XLPHIEUNHAP();
            tblPhieuNhap_CT = new XLPHIEUNHAP_CT();
            dgTimKiemHN.AutoGenerateColumns = false;
            dgTimKiemHN.DataSource = tblPhieuNhap;
            DSTKHN = this.BindingContext[tblPhieuNhap];
            LoadPhieuNhapCT();
        }
        private void LoadPhieuNhapCT()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblPhieuNhap_CT, tblPhieuNhap });
            ds.Relations.Add(new DataRelation("FRK_PHIEUNHAP_CT_PHIEUNHAP", tblPhieuNhap_CT.Columns["SoPhieuNhap"], tblPhieuNhap.Columns["SoPhieuNhap"]));
            DataColumn cot_SoLuong = new DataColumn("SoLuong", Type.GetType("System.String"), "Parent(FRK_PHIEUNHAP_CT_PHIEUNHAP).SoLuong");
            tblPhieuNhap.Columns.Add(cot_SoLuong);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_PHIEUNHAP_CT_PHIEUNHAP).DonGia");
            tblPhieuNhap.Columns.Add(cot_DonGia);
            DataColumn cot_ThanhTien = new DataColumn("ThanhTien", Type.GetType("System.String"), "Parent(FRK_PHIEUNHAP_CT_PHIEUNHAP).ThanhTien");
            tblPhieuNhap.Columns.Add(cot_ThanhTien);
            DataColumn cot_MaSP = new DataColumn("MaSP", Type.GetType("System.String"), "Parent(FRK_PHIEUNHAP_CT_PHIEUNHAP).MaSP");
            tblPhieuNhap.Columns.Add(cot_MaSP);
            DataColumn cot_MaNCC = new DataColumn("MaNCC", Type.GetType("System.String"), "Parent(FRK_PHIEUNHAP_CT_PHIEUNHAP).MaNCC");
            tblPhieuNhap.Columns.Add(cot_MaNCC);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblPhieuNhap.Select("MaSP='" + txtSoPhieuNhap.Text + "' and TenSP='" + dateNhapHang.Text + "'")[0];
                DSTKHN.Position = tblPhieuNhap.Rows.IndexOf(r);
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

        private void dgTimKiemHN_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemHN.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void dateNhapHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void dateNhapHang_MouseDown(object sender, MouseEventArgs e)
        {
            dateNhapHang.Text = "";
        }

        private void txtSoPhieuNhap_MouseDown(object sender, MouseEventArgs e)
        {
            txtSoPhieuNhap.Text = "";
        }

        private void txtSoPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }
    }
}
