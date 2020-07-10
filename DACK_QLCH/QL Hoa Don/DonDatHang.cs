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
        XLNHANVIEN tblNhanVien;
        bool capNhat = false;
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblNhanVien = new XLNHANVIEN();
            loadHoaDon();
            ennableButton();
        }
        private void loadHoaDon()
        {
            txtSoHD.DataBindings.Add("text", tblHoaDon, "SoHD", true);
            txtTenNV.DataBindings.Add("text", tblNhanVien, "HoTen", true);
            txtMaNV.DataBindings.Add("text", tblHoaDon, "MaNV", true);
            dateGiaoHang.DataBindings.Add("text", tblHoaDon, "NgayGH", true);
            txtDiaChi.DataBindings.Add("text", tblHoaDon, "DiaChi", true);
            txtKhachHang.DataBindings.Add("text", tblHoaDon, "TenKH", true);
            txtSDT.DataBindings.Add("text", tblHoaDon, "SDT", true);
            txtTinhTrang.DataBindings.Add("text", tblHoaDon, "TinhTrangGiao", true);
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDon;
        }
        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoat.Enabled = capNhat;
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
