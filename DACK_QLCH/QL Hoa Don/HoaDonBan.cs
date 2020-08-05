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
using DevExpress.XtraEditors.NavigatorButtons;

namespace DACK_QLCH.QL_Hoa_Don
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        XLHOADON_CT tblHoaDon_CT;
        XLSANPHAM tblSanPham;
        XLKHACHHANG tblKhachHang;
        XLNHANVIEN tblNhanVien;
        XLHOADON tblHoaDon;
        BindingManagerBase DSHD;
        bool capNhat = false;

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            tblHoaDon_CT = new XLHOADON_CT();
            tblSanPham = new XLSANPHAM();
            tblNhanVien = new XLNHANVIEN();
            tblKhachHang = new XLKHACHHANG();
            tblHoaDon = new XLHOADON();
            loadHoaDon();
            LoadHoaDon();
            cbMaSP();
            cbMaKH();
            cbMaNV();
            tinhtien();
            ////BdpDB_PositionChange(sender, e);
            ennableButton();

        }
        private void LoadHoaDon()
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
            cot_NgayHD.DefaultValue = DateTime.Now;

        }
        private void tinhtien()
        {
           
            for (int r = 0; r < dgDSDBH.Rows.Count; r++)
            {
                dgDSDBH.Rows[r].Cells[10].Value = Convert.ToInt32(dgDSDBH.Rows[r].Cells[8].Value) * Convert.ToInt32(dgDSDBH.Rows[r].Cells[9].Value);
                txtThanhTien.Text=dgDSDBH.Rows[r].Cells[10].Value.ToString();
            }
        }
        //private void BdpDB_PositionChange(object sender, EventArgs e)
        //{
        //    tblHoaDon_CT.DefaultView.RowFilter = " MaSP='" + cboMaSP.Text + "'";
        //    int s = 0;
        //    foreach (DataRowView r in tblHoaDon_CT.DefaultView)
        //    {
        //        s += int.Parse(r["DonGia"].ToString());

        //    }
        //    txtDonGia.Text = s.ToString();
        //}
        private void cbMaSP()
        {
            cboMaSP.DataSource = tblSanPham;
            cboMaSP.ValueMember = "MaSP";
            cboMaSP.DisplayMember = "MaSP";
            cboMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaSP.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void cbMaKH()
        {
            cboMaKH.DataSource = tblKhachHang;
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaKH.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void cbMaNV()
        {
            cboMaNV.DataSource = tblNhanVien;
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaNV.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void loadHoaDon()
        {
            txtSoHDCT.DataBindings.Add("text", tblHoaDon_CT, "SoHDCT", true);
            txtSoHD.DataBindings.Add("text", tblHoaDon_CT, "SoHD", true);
            //txtThanhTien.DataBindings.Add("text", tblHoaDon_CT, "ThanhTien", true);
            txtSoLuong.DataBindings.Add("text",tblHoaDon_CT,"SoLuong",true);
            cboMaSP.DataBindings.Add("selectedvalue",tblHoaDon_CT,"MaSP",true);
            DSHD = this.BindingContext[tblHoaDon_CT];
            dgDSDBH.AutoGenerateColumns = false;
            dgDSDBH.DataSource = tblHoaDon_CT;
            //DSHD.PositionChanged += new EventHandler(BdpDB_PositionChange);

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
            txtThanhTien.Enabled = capNhat;
            txtDonGia.Enabled = capNhat;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.AddNew();
                tinhtien();
                //BdpDB_PositionChange(sender, e);
                capNhat = true;
                ennableButton();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại!!!");

                tblHoaDon_CT.RejectChanges();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                capNhat = true;
                ennableButton();
            }
            catch
            {
                MessageBox.Show("Sửa thất bại!!!");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa hóa đơn " + txtSoHDCT.Text + " không?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DSHD.RemoveAt(DSHD.Position);
                    tblHoaDon_CT.ghi();
                    tblHoaDon_CT.AcceptChanges();
                    capNhat = true;
                    ennableButton();
                    MessageBox.Show("Xóa thành công!");
                }

            }
            catch (SqlException)
            {
                tblHoaDon_CT.RejectChanges();
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.EndCurrentEdit();
                tblHoaDon_CT.ghi();
                tinhtien();
                tblHoaDon_CT.AcceptChanges();
                //BdpDB_PositionChange(sender,e);
                MessageBox.Show("Cập nhật thành công!!!");
                capNhat = false;
                ennableButton();
            }
            catch (Exception ex)
            {
                tblHoaDon_CT.RejectChanges();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            DSHD.CancelCurrentEdit();
            tblHoaDon_CT.RejectChanges();
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
                DataRow r = tblHoaDon_CT.Select("SoHDCT ='" + txtTimKiem.Text + "'")[0];
                DSHD.Position = tblHoaDon_CT.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void dgDSDBH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDBH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void dgDSDBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMaNV.Text = dgDSDBH.Rows[DSHD.Position].Cells[3].Value.ToString();
            cboMaKH.Text = dgDSDBH.Rows[DSHD.Position].Cells[4].Value.ToString();
            txtDonGia.Text = dgDSDBH.Rows[DSHD.Position].Cells[9].Value.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
