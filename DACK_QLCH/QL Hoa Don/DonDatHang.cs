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

namespace DACK_QLCH.QL_Hoa_Don
{
    public partial class frmDonDatHang : Form
    {
        public frmDonDatHang()
        {
            InitializeComponent();
        }
       
        XLHOADON_CT tblHoaDon_CT;
        XLSANPHAM tblSanPham;
        XLKHACHHANG tblKhachHang;
        XLNHANVIEN tblNhanVien;
        BindingManagerBase DSHD;
        bool capNhat=false;
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            
            tblHoaDon_CT=new XLHOADON_CT();
            tblSanPham = new XLSANPHAM();
            tblNhanVien = new XLNHANVIEN();
            tblKhachHang = new XLKHACHHANG();


            ennableButton();
        }
      
        private void ennableButton()
        {
           
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
                tblHoaDon_CT.ghi();
                tblHoaDon_CT.AcceptChanges();
                capNhat = true;
                ennableButton();

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
            tblHoaDon_CT.RejectChanges();
            tblHoaDon_CT.AcceptChanges();
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
                DataRow r = tblHoaDon_CT.Select("SoHD ='" + txtTimKiem.Text + "'")[0];
                DSHD.Position = tblHoaDon_CT.Rows.IndexOf(r);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
