using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DACK_QLCH.Moduls;
using DevExpress.Utils.Extensions;
using System.Data.SqlClient;

namespace DACK_QLCH.QL_San_Pham
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
     
        XLSANPHAM tblSanPham;
        bool capNhat = false;

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            tblSanPham = new XLSANPHAM();
            LoadDSSP();
            ennableButton();
        }
        private void LoadDSSP()
        {
            txtMaSP.DataBindings.Add("text", tblSanPham, "MaSP",true);
            txtTenSP.DataBindings.Add("text", tblSanPham, "TenSP", true);
            txtNoiSanXuat.DataBindings.Add("text", tblSanPham, "NoiSX", true);
            txtDonGia.DataBindings.Add("text", tblSanPham, "DonGia", true);
            txtDonViTinh.DataBindings.Add("text", tblSanPham, "DonViTinh", true);
            dateNgaySanXuat.DataBindings.Add("text", tblSanPham, "NgaySX", true);
            dgDSSP.AutoGenerateColumns = false;
            dgDSSP.DataSource = tblSanPham;
        }

        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoat.Enabled = capNhat;
            btnTimKiem.Enabled = capNhat;
        }

        private void dgDSSP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in dgDSSP.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }
    }
}
