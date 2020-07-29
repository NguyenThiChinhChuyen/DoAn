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
        BindingManagerBase DSHD;
        bool capNhat=false;
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            tblHoaDon = new XLHOADON();
            tblHOADON_CT = new XLHOADON_CT();
            loadHoaDon();
            LoadHoaDon_CTdgDONDATHANG();
            DSHD = this.BindingContext[tblHoaDon];
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
            txtDonGia.DataBindings.Add("text", tblHOADON_CT, "DonGia", true);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.AddNew();
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

                capNhat = true;
                ennableButton();

            }
            catch (SqlException)
            {
                tblHoaDon.RejectChanges();
                tblHOADON_CT.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.EndCurrentEdit();
                tblHoaDon.ghi();
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
