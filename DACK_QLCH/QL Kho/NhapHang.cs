using DevExpress.ClipboardSource.SpreadsheetML;
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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        XLPHIEUNHAP_CT tblPhieuNhap_CT;
        XLSANPHAM tblSanPham;

        XLNCC tblNCC;
        BindingManagerBase DSPN;
        bool capNhat = false;
     

        private void frmNhaHang_Load(object sender, EventArgs e)
        {
            tblPhieuNhap_CT = new XLPHIEUNHAP_CT();
            tblNCC = new XLNCC();
            tblSanPham = new XLSANPHAM();
            cbNCC();
            cbMaSP();
            loadPhieuNhap();
            ennableButton();
      
        }

        private void loadPhieuNhap()
        {
            txtSoPN.DataBindings.Add("text", tblPhieuNhap_CT, "SoPhieuNhap", true);
            cboMaSP.DataBindings.Add("SelectedValue",tblPhieuNhap_CT,"MaSP",true);
            txtSoLuong.DataBindings.Add("text", tblPhieuNhap_CT,"SoLuong", true);
            cboNCC.DataBindings.Add("SelectedValue", tblPhieuNhap_CT, "MaNCC", true);
            txtDonGia.DataBindings.Add("text", tblPhieuNhap_CT, "DonGia", true);
            txtThanhTien.DataBindings.Add("text", tblPhieuNhap_CT, "ThanhTien", true);
            dateNgayPN.DataBindings.Add("text", tblPhieuNhap_CT , "NgayPhieuNhap", true);
            DSPN = BindingContext[tblPhieuNhap_CT];
            dgDSNH.AutoGenerateColumns = false;
            dgDSNH.DataSource = tblPhieuNhap_CT;
        }
        private void cbMaSP()
        {
            cboMaSP.DataSource = tblSanPham;
            cboMaSP.ValueMember = "MaSP";
            cboMaSP.DisplayMember = "MaSP";
            cboMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaSP.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void cbNCC()
        {
            cboNCC.DataSource = tblNCC;
            cboNCC.DisplayMember = "MaNCC";
            cboNCC.ValueMember = "MaNCC";
            cboNCC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboNCC.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoat.Enabled = !capNhat;
        }

        private void dgDSNH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSNH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSPN.AddNew();
                capNhat = true;
                ennableButton();
                MessageBox.Show("Thêm thành công, Bạn có muốn Lưu không!!!");
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
                DSPN.RemoveAt(DSPN.Position);
                tblPhieuNhap_CT.ghi();
                tblPhieuNhap_CT.AcceptChanges();
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblPhieuNhap_CT.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSPN.EndCurrentEdit();
                tblPhieuNhap_CT.ghi();
                tblPhieuNhap_CT.AcceptChanges();
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
            DSPN.CancelCurrentEdit();
            tblPhieuNhap_CT.RejectChanges();
            tblPhieuNhap_CT.AcceptChanges();
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
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblPhieuNhap_CT.Select("SoPhieuNhap ='" + txtTimKiem.Text + "'")[0];
                DSPN.Position = tblPhieuNhap_CT.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
