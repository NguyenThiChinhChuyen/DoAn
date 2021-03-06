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

namespace DACK_QLCH
{
    public partial class frmTimKiemDonDaLap : Form
    {
        public frmTimKiemDonDaLap()
        {
            InitializeComponent();
        }
        XLHOADON tblHoaDon;
        XLHOADON_CT tblHoaDon_CT;
        XLSANPHAM tblSanPham;
        BindingManagerBase DSHD;
        bool capNhat = false;
        private void TimKiemDonDaLap_Load(object sender, EventArgs e)
        {
            tblHoaDon_CT = new XLHOADON_CT();
            tblHoaDon = new XLHOADON();
            tblSanPham = new XLSANPHAM();
            tinhtien();
            LoadHoaDoncoi();
            enable();

        }
        private void enable()
        {
            txtThanhTien.Enabled = capNhat;
        }
        private void LoadHoaDoncoi()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHoaDon_CT, tblSanPham, tblHoaDon });
            DataRelation qh = new DataRelation("FPK_SANPHAM_HOADON_CT", tblSanPham.Columns["MaSP"], tblHoaDon_CT.Columns["MaSP"]);
            DataRelation qx = new DataRelation("FPK_HOADON_HOADON_CT", tblHoaDon.Columns["SoHD"], tblHoaDon_CT.Columns["SoHD"]);
            ds.Relations.Add(qx);
            ds.Relations.Add(qh);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADON_CT).DonGia");
            tblHoaDon_CT.Columns.Add(cot_DonGia);
            DataColumn cot_TenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADON_CT).TenSP");
            tblHoaDon_CT.Columns.Add(cot_TenSP);
            DataColumn cot_MaKH = new DataColumn("MaKH", Type.GetType("System.String"), "Parent(FPK_HOADON_HOADON_CT).MaKH");
            tblHoaDon_CT.Columns.Add(cot_MaKH);
            DataColumn cot_MaNV = new DataColumn("MaNV", Type.GetType("System.String"), "Parent(FPK_HOADON_HOADON_CT).MaNV");
            tblHoaDon_CT.Columns.Add(cot_MaNV);
            DataColumn cot_NgayHD = new DataColumn("NgayHD", Type.GetType("System.String"), "Parent(FPK_HOADON_HOADON_CT).NgayHD");
            tblHoaDon_CT.Columns.Add(cot_NgayHD);
            txtThanhTien.DataBindings.Add("text", tblHoaDon_CT, "ThanhTien", true);
            DSHD = this.BindingContext[tblHoaDon_CT];
            dgTimKiemDDL.AutoGenerateColumns = false;
            dgTimKiemDDL.DataSource = tblHoaDon_CT;
        }
        private void tinhtien()
        {
            for (int r = 0; r < dgTimKiemDDL.Rows.Count; r++)
            {
                dgTimKiemDDL.Rows[r].Cells[10].Value = Convert.ToInt32(dgTimKiemDDL.Rows[r].Cells[8].Value) * Convert.ToInt32(dgTimKiemDDL.Rows[r].Cells[9].Value); 
            }
           
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage T = (TabPage)this.Parent;
            T.Dispose();
        }

        private void dgTimKiemDDL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgTimKiemDDL.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }



        private void dgTimKiemDDL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            {
                if (radSoHD.Checked == true)
                {
                    string std = string.Format("SoHDCT like '%{0}%'", txtTimKiem.Text);
                    tblHoaDon_CT.DefaultView.RowFilter = std;
                }
                else
                {
                    string std = string.Format("SoHD like '%{0}%'", txtTimKiem.Text);
                    tblHoaDon_CT.DefaultView.RowFilter = std;
                }

            }
        }
    }
}
