
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

namespace DACK_QLCH
{
    public partial class frmNhaHang : Form
    {
        public frmNhaHang()
        {
            InitializeComponent();
        }
        XLPHIEUNHAP tblPhieuNhap;
        bool capNhat = false;
        private void frmNhaHang_Load(object sender, EventArgs e)
        {
            tblPhieuNhap = new XLPHIEUNHAP();
            loadPhieuNhap();
            ennableButton();
        }
        private void loadPhieuNhap()
        {
            dateNgayPN.DataBindings.Add("text",tblPhieuNhap,"NgayPhieuNhap",true);
            txtSoPN.DataBindings.Add("text", tblPhieuNhap, "SoPhieuNhap", true);
            txtMaNCC.DataBindings.Add("text", tblPhieuNhap, "MaNCC", true);
            txtMaNV.DataBindings.Add("text", tblPhieuNhap, "MaNV", true);
            txtNoiDungPN.DataBindings.Add("text", tblPhieuNhap, "NoiDung", true);
            dgDSNH.AutoGenerateColumns = false;
            dgDSNH.DataSource = tblPhieuNhap;
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

        private void dgDSNH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgDSNH.Rows)
            {
                r.Cells[0].Value = r.Index +1;
            }
        }
    }
}
