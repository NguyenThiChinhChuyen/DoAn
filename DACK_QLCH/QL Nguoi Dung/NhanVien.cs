using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DACK_QLCH.Moduls;

namespace DACK_QLCH.QL_Nguoi_Dung
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        XLNHANVIEN tblNhanVien;
        BindingManagerBase DSNV;
        bool capNhat = false;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            tblNhanVien = new XLNHANVIEN();
            LoadDSNV();
            DSNV = this.BindingContext[tblNhanVien];
            ennableButton();
        }

        private void LoadDSNV()
        {
            txtMaNV.DataBindings.Add("text", tblNhanVien, "MaNV", true);
            txtTenNV.DataBindings.Add("text", tblNhanVien, "HoTen", true);
            txtDiaChi.DataBindings.Add("text", tblNhanVien, "DiaChi", true);
            txtEmail.DataBindings.Add("text", tblNhanVien, "Email", true);
            txtSDT.DataBindings.Add("text", tblNhanVien, "SDT", true);
            txtChucVu.DataBindings.Add("text", tblNhanVien, "ChucVu", true);
            dgDSNV.AutoGenerateColumns = false;
            dgDSNV.DataSource = tblNhanVien;
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

        private void dgDSNV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSNV.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSNV.AddNew();
                capNhat = true;
                ennableButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSNV.EndCurrentEdit();
                tblNhanVien.ghi();
                tblNhanVien.AcceptChanges();
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
            DSNV.CancelCurrentEdit();
            tblNhanVien.RejectChanges();
            capNhat = false;
            ennableButton();
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
                DSNV.RemoveAt(DSNV.Position);
                tblNhanVien.ghi();
                tblNhanVien.AcceptChanges();
                capNhat = true;
                ennableButton();
            }
            catch (SqlException)
            {
                tblNhanVien.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                DataRow r = tblNhanVien.Select("MaNV ='" + txtTimKiem.Text + "'")[0];
                DSNV.Position = tblNhanVien.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
