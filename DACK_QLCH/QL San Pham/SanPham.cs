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
            txtSoLuongTon.DataBindings.Add("text",tblSanPham,"SoLuongTon",true);
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
            btnThoat.Enabled = !capNhat;
            btnTimKiem.Enabled = !capNhat;
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

                DSSP.AddNew();
                capNhat = true;
                ennableButton();
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
            try
            {
                DSSP.RemoveAt(DSSP.Position);
                tblSanPham.ghi();
                tblSanPham.AcceptChanges();
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblSanPham.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSSP.EndCurrentEdit();
                tblSanPham.ghi();
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
            DSSP.CancelCurrentEdit();
            tblSanPham.RejectChanges();
            capNhat = false;
            ennableButton();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void txtTimKiem_MouseDown(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblSanPham.Select("MaSP ='" + txtTimKiem.Text + "'")[0];
                DSSP.Position = tblSanPham.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
