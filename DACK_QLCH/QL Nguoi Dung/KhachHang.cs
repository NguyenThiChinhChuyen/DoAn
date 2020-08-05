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
using System.Data.SqlClient;

namespace DACK_QLCH.QL_Nguoi_Dung
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        XLKHACHHANG tblKhachHang;
        BindingManagerBase DSKH;
        bool capNhat = false;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            tblKhachHang = new XLKHACHHANG();
            LoadDSKH();
            DSKH = this.BindingContext[tblKhachHang];
            ennableButton();
        }

        private void LoadDSKH()
        {
            txtMaKH.DataBindings.Add("text", tblKhachHang, "MaKH", true);
            txtTenKH.DataBindings.Add("text", tblKhachHang, "TenKH", true);
            txtDiaChi.DataBindings.Add("text", tblKhachHang, "DiaChi", true);         
            txtSDT.DataBindings.Add("text", tblKhachHang, "SDT", true);
            radNam.DataBindings.Add("checked", tblKhachHang, "GioiTinh", true);
            dgDSKH.AutoGenerateColumns = false;
            dgDSKH.DataSource = tblKhachHang;
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

        private void dgDSKH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSKH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {
            radNu.Checked = !radNam.Checked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSKH.AddNew();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSKH.EndCurrentEdit();
                tblKhachHang.ghi();
                tblKhachHang.AcceptChanges();
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
            DSKH.CancelCurrentEdit();
            tblKhachHang.RejectChanges();
            capNhat = false;
            ennableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSKH.RemoveAt(DSKH.Position);
                tblKhachHang.ghi();
                tblKhachHang.AcceptChanges();
                capNhat = true;
                ennableButton();
            }
            catch (SqlException)
            {
                tblKhachHang.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
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
                DataRow r = tblKhachHang.Select("MaKH ='" + txtTimKiem.Text + "'")[0];
                DSKH.Position = tblKhachHang.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
