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

namespace DACK_QLCH.QL_Hoa_Don
{
    public partial class frmDonDatHang : Form
    {
        public frmDonDatHang()
        {
            InitializeComponent();
        }
        XLHOADON tblHoaDon;
        XLHOADON_CT tblHOADON_CT;
        bool capNhat=false;
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblHOADON_CT = new XLHOADON_CT();
            loadHoaDon();
            LoadHoaDon_CTdgDONDATHANG();
            ennableButton();
        }
        private void LoadHoaDon_CTdgDONDATHANG()
        {
            var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHOADON_CT, tblHoaDon });
            ds.Relations.Add(new DataRelation("FRK_HOADON_CT_HOADON", tblHOADON_CT.Columns["SoHD"], tblHoaDon.Columns["SoHD"]));
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
            dateGiaoHang.DataBindings.Add("text", tblHoaDon, "NgayGH", true);
            txtDiaChi.DataBindings.Add("text", tblHoaDon, "DiaChi", true);
            txtKhachHang.DataBindings.Add("text", tblHoaDon, "TenKH", true);
            txtSDT.DataBindings.Add("text", tblHoaDon, "SDT", true);
            txtTinhTrang.DataBindings.Add("text", tblHoaDon, "TinhTrangGiao", true);
            txtThanhTien.DataBindings.Add("text", tblHOADON_CT, "ThanhTien", true);
            txtDonGia.DataBindings.Add("text", tblHOADON_CT, "DonnGia", true);
            txtSoLuong.DataBindings.Add("text", tblHOADON_CT, "SoLuong", true);
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource =  tblHoaDon;
       
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

        private void dgDSDDH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDDH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }


    }
}
