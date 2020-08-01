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
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        XLHOADON tblHoaDon;
        XLSANPHAM tblSanPham;
        XLKHACHHANG tblKhachHang;
        XLNHANVIEN tblNhanVien;
        BindingManagerBase DSHD;
        bool capNhat = false;
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblSanPham = new XLSANPHAM();
            tblNhanVien = new XLNHANVIEN();
            tblKhachHang = new XLKHACHHANG();
            loadHoaDon();
            LoadHoaDon();
            cbMaSP();
            cboMaNV_Load();
            cbMaKH();
            ennableButton();
        }
        private void cbMaSP()
        {
            cboMaSP.DataSource = tblSanPham;
            cboMaSP.DisplayMember = "MaSP";
            cboMaSP.ValueMember = "MaSP";
        }
        private void cbMaKH()
        {
            cboMaKH.DataSource = tblKhachHang;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
        }
        private void LoadHoaDon()
        {
           var ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblSanPham, tblHoaDon, tblKhachHang });
            ds.Relations.Add(new DataRelation("FRK_SANPHAM_HOADON", tblSanPham.Columns["MaSP"], tblHoaDon.Columns["MaSP"]));
            DataColumn cot_TenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FRK_SANPHAM_HOADON).TenSP");
            tblHoaDon.Columns.Add(cot_TenSP);
        }
        private void cboMaNV_Load()
        {
            cboMaNV.DataSource = tblNhanVien;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
        }
        private void loadHoaDon()
        {
            txtSoHD.DataBindings.Add("text", tblHoaDon, "SoHD", true);
            dateNgayLap.DataBindings.Add("text", tblHoaDon, "NgayHD", true);
            cboMaNV.DataBindings.Add("SelectedValue", tblHoaDon, "MaNV", true);
            cboMaSP.DataBindings.Add("SelectedValue", tblHoaDon, "MaSP", true);
            cboMaKH.DataBindings.Add("SelectedValue", tblHoaDon, "MaKH", true);
            txtThanhTien.DataBindings.Add("text", tblHoaDon, "ThanhTien", true);
            txtDonGia.DataBindings.Add("text", tblHoaDon, "DonGia", true);
            txtSoLuong.DataBindings.Add("text", tblHoaDon, "SoLuong", true);
            DSHD = this.BindingContext[tblHoaDon];
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
            btnThoat.Enabled = !capNhat;
            btnTimKiem.Enabled = capNhat;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.AddNew();
                capNhat = true;
                ennableButton();
                MessageBox.Show("Bạn có muốn Thêm không!!!");
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
                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblHoaDon.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.EndCurrentEdit();
                tblHoaDon.ghi();
                tblHoaDon.AcceptChanges();
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
            DSHD.EndCurrentEdit();
            tblHoaDon.RejectChanges();
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
            if(e.KeyChar==(char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblHoaDon.Select("SoHD ='" + txtTimKiem.Text + "'")[0];
                DSHD.Position = tblHoaDon.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }



    }
}
