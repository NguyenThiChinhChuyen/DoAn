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
using DevExpress.XtraEditors.NavigatorButtons;
using DACK_QLCH.Moduls;

namespace DACK_QLCH.QL_Hoa_Don
{
    public partial class frmDonDatHang : Form
    {
        public frmDonDatHang()
        {
            InitializeComponent();
        }
       
        XLHOADONDH_CT tblHoaDonDH_CT;
        XLSANPHAM tblSanPham;
        XLNHANVIEN tblNhanVien;
        BindingManagerBase DSHDDH;
        bool capNhat=false;
        //SFFC
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
          
            tblHoaDonDH_CT=new XLHOADONDH_CT();
            tblSanPham = new XLSANPHAM();
            tblNhanVien = new XLNHANVIEN();
            loadDonDatHang();
            LoadDonDatHang();
            tinhtien();
            cbMaSP();
            cbMaNV();
            ennableButton();
        }

        private void LoadDonDatHang()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblHoaDonDH_CT, tblSanPham});
            DataRelation qh = new DataRelation("FPK_SANPHAM_HOADONDH_CT", tblSanPham.Columns["MaSP"], tblHoaDonDH_CT.Columns["MaSP"]);
            ds.Relations.Add(qh);
            DataColumn cot_TenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADONDH_CT).TenSP");
            tblHoaDonDH_CT.Columns.Add(cot_TenSP);
            DataColumn cot_DonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FPK_SANPHAM_HOADONDH_CT).DonGia");
            tblHoaDonDH_CT.Columns.Add(cot_DonGia);

        }
        private void tinhtien()
        {
            for (int r = 0; r < dgDSDDH.Rows.Count; r++)
            {
                dgDSDDH.Rows[r].Cells[12].Value = Convert.ToInt32(dgDSDDH.Rows[r].Cells[10].Value) * Convert.ToInt32(dgDSDDH.Rows[r].Cells[11].Value);
                txtThanhTien.Text = dgDSDDH.Rows[r].Cells[12].Value.ToString(); 
            }
        }
        private void loadDonDatHang()
        {
            txtSoHDDH.DataBindings.Add("text", tblHoaDonDH_CT, "SoHDDH", true);
            txtSoLuong.DataBindings.Add("text", tblHoaDonDH_CT, "SoLuong", true);
            txtTenKH.DataBindings.Add("text", tblHoaDonDH_CT, "TenKHGH", true);
            cboMaNV.DataBindings.Add("SelectedValue", tblHoaDonDH_CT, "MaNV", true);
            cboMaSP.DataBindings.Add("SelectedValue", tblHoaDonDH_CT, "MaSP", true);
            txtSDT.DataBindings.Add("text", tblHoaDonDH_CT, "SDTGH", true);
            txtDiaChiGH.DataBindings.Add("text",tblHoaDonDH_CT,"DiaChiGH",true);
            radChuaGiao.DataBindings.Add("checked", tblHoaDonDH_CT, "TinhTrang", true);
            DSHDDH = this.BindingContext[tblHoaDonDH_CT];
            dgDSDDH.AutoGenerateColumns = false;
            dgDSDDH.DataSource = tblHoaDonDH_CT;
        }
        private void cbMaSP()
        {
            cboMaSP.DataSource = tblSanPham;
            cboMaSP.DisplayMember = "MaSP";
            cboMaSP.ValueMember = "MaSP";
            cboMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaSP.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
       
        private void cbMaNV()
        {
            cboMaNV.DataSource = tblNhanVien;
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaNV.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ennableButton()
        {
            txtDonGia.Enabled = capNhat;
            txtThanhTien.Enabled = capNhat;
            btnSua.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThoat.Enabled = !capNhat;
            btnTimKiem.Enabled = !capNhat;
        }

        private void dgDSDDH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSDDH.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
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
                if (MessageBox.Show("Bạn có muốn xóa hóa đơn " + txtSoHDDH.Text + " không?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DSHDDH.RemoveAt(DSHDDH.Position);
                    tblHoaDonDH_CT.ghi();
                    tblHoaDonDH_CT.AcceptChanges();
                    capNhat = true;
                    ennableButton();
                    MessageBox.Show("Xóa thành công!");
                }

            }
            catch (SqlException)
            {
                tblHoaDonDH_CT.RejectChanges();
              
                MessageBox.Show("Xóa thất bại!!!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHDDH.EndCurrentEdit();
                tblHoaDonDH_CT.ghi();
                dgDSDDH.Rows[DSHDDH.Position].Cells[8].Value = DateTime.Now;
                tblHoaDonDH_CT.AcceptChanges();
                tinhtien();
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
            DSHDDH.CancelCurrentEdit();
            tblHoaDonDH_CT.AcceptChanges();
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
                DataRow r = tblHoaDonDH_CT.Select("SoHD ='" + txtTimKiem.Text + "'")[0];
                DSHDDH.Position = tblHoaDonDH_CT.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DSHDDH.AddNew();
                dgDSDDH.Rows[DSHDDH.Position].Cells[8].Value = DateTime.Now;
                tinhtien();
                //BdpDB_PositionChange(sender, e);
                capNhat = true;
                ennableButton();
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại!!!");

                tblHoaDonDH_CT.RejectChanges();
                MessageBox.Show(ex.Message);
            }
        }

        private void radChuaGiao_CheckedChanged(object sender, EventArgs e)
        {
            radGiao.Checked = !radChuaGiao.Checked;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
