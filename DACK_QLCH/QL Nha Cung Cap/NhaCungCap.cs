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
using System.IO;
using DevExpress.Xpo.DB;

namespace DACK_QLCH.QL_Nha_Cung_Cap
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        XLNCC tblNCC;
        BindingManagerBase DSSP;
        bool capNhat = false;

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            tblNCC = new XLNCC();
            LoadDSSP();
            DSSP = this.BindingContext[tblNCC];
            ennableButton();
        }
        private void LoadDSSP()
        {
            txtMaNCC.DataBindings.Add("text", tblNCC, "MaNCC", true);
            txtTenNCC.DataBindings.Add("text", tblNCC, "TenNCC", true);
            txtDiaChi.DataBindings.Add("text", tblNCC, "DiaChi", true);
            txtDienThoai.DataBindings.Add("text", tblNCC, "DienThoai", true);
            txtEmail.DataBindings.Add("text", tblNCC, "Email", true);
            //txtTimKiem.DataBindings.Add("text", tblNCC, "NgaySX", true);
            dgDSNCC.AutoGenerateColumns = false;
            dgDSNCC.DataSource = tblNCC;
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
    
        private void dgDSNCC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in dgDSNCC.Rows)
                r.Cells[0].Value = r.Index + 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                DSSP.AddNew();
                capNhat = true;
                ennableButton();
            }
            catch (Exception ex)
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
                tblNCC.ghi();
                tblNCC.AcceptChanges();
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblNCC.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSSP.EndCurrentEdit();
                tblNCC.ghi();
                MessageBox.Show("Cập nhật thành công!!!");
                capNhat = false;
                ennableButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DSSP.CancelCurrentEdit();
            tblNCC.RejectChanges();
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
            txtTimKiem.Text = " Nhap Thong Tin Tim Kiem ";
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblNCC.Select("MaSP ='" + txtTimKiem.Text + "'")[0];
                DSSP.Position = tblNCC.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
