
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
        XLPHIEUNHAP tblPhieuNhap;
        XLPHIEUNHAP_CT tblPhieuNhap_CT;
        BindingManagerBase DSPN;
        BindingManagerBase DSPNCT;
        bool capNhat = false;
        XLNHANVIEN tblNhanVien;
        XLNCC tblNCC;
        private void frmNhaHang_Load(object sender, EventArgs e)
        {
            tblPhieuNhap = new XLPHIEUNHAP();
            tblPhieuNhap_CT = new XLPHIEUNHAP_CT();
            tblNhanVien = new XLNHANVIEN();
            tblNCC = new XLNCC();
            DSPN = this.BindingContext[tblPhieuNhap];
            DSPNCT = this.BindingContext[tblPhieuNhap_CT];
            loadPhieuNhap();
            LoadPhieuNhapCT();
            cbMaNV();
            cbNCC();
            ennableButton();
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
        }
        private void loadPhieuNhap()
        {
            dateNgayPN.DataBindings.Add("text",tblPhieuNhap,"NgayPhieuNhap",true);
            txtSoPN.DataBindings.Add("text", tblPhieuNhap, "SoPhieuNhap", true);
            cboNCC.DataBindings.Add("SelectedValue", tblPhieuNhap, "MaNCC", true);
            txtMaSP.DataBindings.Add("text", tblPhieuNhap_CT, "MaSP", true);
            cboMaNV.DataBindings.Add("SelectedValue",tblPhieuNhap,"MaNV",true);
            txtNoiDungPN.DataBindings.Add("text", tblPhieuNhap, "NoiDung", true);
            txtDonGia.DataBindings.Add("text", tblPhieuNhap_CT, "DonGia", true);
            txtSoLuong.DataBindings.Add("text", tblPhieuNhap_CT, "SoLuong", true);
            txtThanhTien.DataBindings.Add("text", tblPhieuNhap_CT, "ThanhTien", true);
            dgDSNH.AutoGenerateColumns = false;
            dgDSNH.DataSource = tblPhieuNhap;
        }
        
        private void cbMaNV()
        {
            cboMaNV.DataSource = tblNhanVien;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
        }
        private void cbNCC()
        {
            cboNCC.DataSource = tblNCC;
            cboNCC.DisplayMember = "MaNCC";
            cboNCC.ValueMember = "MaNCC";
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

        private void dgDSNH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSNH.Rows)
            {
                r.Cells[0].Value = r.Index +1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSPN.AddNew();
                DSPNCT.AddNew();
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
                tblPhieuNhap.ghi();
                tblPhieuNhap.AcceptChanges();
                DSPNCT.RemoveAt(DSPNCT.Position);
                tblPhieuNhap_CT.ghi();
                tblPhieuNhap_CT.AcceptChanges();
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblPhieuNhap.RejectChanges();
                tblPhieuNhap_CT.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSPN.CancelCurrentEdit();
                tblPhieuNhap.ghi();
                tblPhieuNhap.AcceptChanges();
                DSPNCT.CancelCurrentEdit();
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
            DSPN.EndCurrentEdit();
            tblPhieuNhap.RejectChanges();
            DSPNCT.CancelCurrentEdit();
            tblPhieuNhap_CT.RejectChanges();
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
                DataRow r = tblPhieuNhap.Select("SoPhieuNhap ='" + txtTimKiem.Text + "'")[0];
                DSPN.Position = tblPhieuNhap.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
