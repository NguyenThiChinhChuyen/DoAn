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
using System.IO;
using DevExpress.Xpo.DB;

namespace DACK_QLCH.QL_San_Pham
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        XLSANPHAM tblSanPham;
        BindingManagerBase DSSP;
        bool capNhat = false;


        private void frmSanPham_Load(object sender, EventArgs e)
        {
            tblSanPham = new XLSANPHAM();
            LoadDSSP();
            dgDSSP.AutoGenerateColumns = false;
            dgDSSP.DataSource = tblSanPham;
            DSSP = this.BindingContext[tblSanPham];
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
        }

        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoat.Enabled = !capNhat;
            btnTimKiem.Enabled = capNhat;
        }

        private void dgDSSP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in dgDSSP.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                capNhat = true;
                ennableButton();
                MessageBox.Show("Thêm thành công, Bạn có muốn Lưu không!!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capNhat = true;
            ennableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                tblSanPham.ghi();
                tblSanPham.AcceptChanges();
                MessageBox.Show("Cập nhật thành công!!!");
                capNhat = false;
                ennableButton();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            tblSanPham.RejectChanges();
            capNhat = false;
            ennableButton();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDSSP_SelectionChanged(object sender, EventArgs e)
        {
            if(capNhat)
            {
                btnHuy_Click(sender, e);
            }
        }
    }
}
