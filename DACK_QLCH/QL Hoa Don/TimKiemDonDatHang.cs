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
        XLKHACHHANG tblKhachHang;
        XLHOADON_CT tblHoaDon_CT;
        BindingManagerBase DGTKDH;

        private void frmTimKiemDonDatHang_Load(object sender, EventArgs e)
        {
        
            tblHoaDon_CT = new XLHOADON_CT();
            tblKhachHang = new XLKHACHHANG();
           
            LoadHoaDon_CTdgDONDATHANG();
        }
        private void LoadHoaDon_CTdgDONDATHANG()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblKhachHang, tblHoaDon_CT });
            ds.Relations.Add(new DataRelation("FRK_KHACHHANG_HOADON_CT", tblKhachHang.Columns["MaKH"], tblHoaDon_CT.Columns["MaKH"]));
            DataColumn cot_TenKH = new DataColumn("TenKH", Type.GetType("System.String"), "Parent(FRK_KHACHHANG_HOADON_CT).TenKH");
            tblHoaDon_CT.Columns.Add(cot_TenKH);
            DataColumn cot_DiaChi = new DataColumn("DiaChi", Type.GetType("System.String"), "Parent(FRK_KHACHHANG_HOADON_CT).DiaChi");
            tblHoaDon_CT.Columns.Add(cot_DiaChi);
            DataColumn cot_SDT = new DataColumn("SDT", Type.GetType("System.String"), "Parent(FRK_KHACHHANG_HOADON_CT).SDT");
            tblHoaDon_CT.Columns.Add(cot_SDT);

            DGTKDH = this.BindingContext[tblHoaDon_CT]; 
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDon_CT;
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
                DataRow r = tblHoaDon_CT.Select("MaSP='" + txtSoHD.Text + "' and NgayGH='" + dateNgayLap.Text + "'")[0];
                DGTKDH.Position = tblHoaDon_CT.Rows.IndexOf(r);
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
