﻿using System;
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

namespace DACK_QLCH.QL_Hoa_Don
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        XLHOADON tblHoaDon;
        XLHOADON_CT tblHoaDon_CT;
        BindingManagerBase DSHD;
        BindingManagerBase DSHDCT;
        bool capNhat = false;
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblHoaDon_CT = new XLHOADON_CT();
            loadHoaDon();
            LoadHoaDon();
            DSHD = this.BindingContext[tblHoaDon];
            ennableButton();
        }
        private void LoadHoaDon()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHoaDon_CT, tblHoaDon });
            ds.Relations.Add(new DataRelation("FRK_HOADON_CT_HOADON", tblHoaDon_CT.Columns["SoHD"], tblHoaDon.Columns["SoHD"]));
            DataColumn cot_SoLuong = new DataColumn("SoLuong", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).SoLuong");
            tblHoaDon.Columns.Add(cot_SoLuong);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).DonGia");
            tblHoaDon.Columns.Add(cot_DonGia);
            DataColumn cot_ThanhTien = new DataColumn("ThanhTien", Type.GetType("System.String"), "Parent(FRK_HOADON_CT_HOADON).ThanhTien");
            tblHoaDon.Columns.Add(cot_ThanhTien);
        }
        private void loadHoaDon()
        {
            txtSoHD.DataBindings.Add("text", tblHoaDon, "SoHD", true);
            dateNgayLap.DataBindings.Add("text", tblHoaDon, "NgayHD", true);
            txtMaNV.DataBindings.Add("text", tblHoaDon, "MaNV", true);
            txtNoiDung.DataBindings.Add("text", tblHoaDon, "NoiDung", true);
            txtThanhTien.DataBindings.Add("text", tblHoaDon_CT, "ThanhTien", true);
            txtDonGia.DataBindings.Add("text", tblHoaDon_CT, "DonGia", true);
            txtSoLuong.DataBindings.Add("text", tblHoaDon_CT, "SoLuong", true);
            dgDSDBH.AutoGenerateColumns = false;
            dgDSDBH.DataSource = tblHoaDon;
        }
        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoát.Enabled = !capNhat;
            btnTimKiem.Enabled = capNhat;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.AddNew();
                DSHDCT.AddNew();
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
                DSHD.RemoveAt(DSHD.Position);
                tblHoaDon.ghi();
                tblHoaDon.AcceptChanges();
                DSHDCT.RemoveAt(DSHD.Position);
                tblHoaDon_CT.ghi();
                tblHoaDon_CT.AcceptChanges();
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblHoaDon.RejectChanges();
                tblHoaDon_CT.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.CancelCurrentEdit();
                tblHoaDon.ghi();
                tblHoaDon.AcceptChanges();
                DSHDCT.CancelCurrentEdit();
                tblHoaDon_CT.ghi();
                tblHoaDon_CT.AcceptChanges();
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
            DSHD.CancelCurrentEdit();
            tblHoaDon.RejectChanges();
            DSHDCT.CancelCurrentEdit();
            tblHoaDon_CT.RejectChanges();
            capNhat = false;
            ennableButton();
        }

        private void btnThoát_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }
    }
}
