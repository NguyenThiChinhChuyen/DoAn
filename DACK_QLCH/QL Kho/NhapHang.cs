﻿using DevExpress.ClipboardSource.SpreadsheetML;
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
        XLSANPHAM tblSanPham;
        XLNCC tblNCC;
        BindingManagerBase DSPN,DSPNCT;
        SqlDataAdapter daNH, daNHCT,daSP;
        bool capNhat = false;

        private void frmNhaHang_Load(object sender, EventArgs e)
        {
            tblPhieuNhap = new XLPHIEUNHAP();
            tblPhieuNhap_CT = new XLPHIEUNHAP_CT();
            tblNCC = new XLNCC();
            tblSanPham = new XLSANPHAM();
            daNH = new SqlDataAdapter("Select*From PHIEUNHAP", XLBANG.cnnStr);
            daNHCT = new SqlDataAdapter("Select*From PHIEUNHAP_CT", XLBANG.cnnStr);
            daSP = new SqlDataAdapter("Select*From SANPHAM",XLBANG.cnnStr);
            try
            {
                daNH.Fill(tblPhieuNhap);
                daNHCT.Fill(tblPhieuNhap_CT);
                daSP.Fill(tblSanPham);
                SqlCommandBuilder cmdPDB = new SqlCommandBuilder(daNH);
                SqlCommandBuilder cmdCTDB = new SqlCommandBuilder(daNHCT);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cbNCC();
            cbMaSP();
            loadPhieuNhap();
            LoadPhieuNhapCT();
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
            cboMaSP.DataBindings.Add("SelectedValue",tblPhieuNhap_CT, "MaSP", true); 
            txtNoiDungPN.DataBindings.Add("text", tblPhieuNhap, "NoiDung", true);
            txtDonGia.DataBindings.Add("text", tblPhieuNhap_CT, "DonGia", true);
            txtSoLuong.DataBindings.Add("text", tblPhieuNhap_CT, "SoLuong", true);
            txtThanhTien.DataBindings.Add("text", tblPhieuNhap_CT, "ThanhTien", true);
            DSPN = this.BindingContext[tblPhieuNhap];
            DSPNCT = this.BindingContext[tblPhieuNhap_CT];
            dgDSNH.AutoGenerateColumns = false;
            dgDSNH.DataSource = tblPhieuNhap;
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
            cboNCC.ValueMember = "TenNCC";
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
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblPhieuNhap.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSPN.EndCurrentEdit();
                tblPhieuNhap.ghi();
                tblPhieuNhap.AcceptChanges();
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
            tblPhieuNhap.RejectChanges();
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
