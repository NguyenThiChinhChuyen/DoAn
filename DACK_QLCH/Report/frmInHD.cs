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

namespace DACK_QLCH.Report
{
    public partial class frmInHD : Form
    {
        public frmInHD()
        {
            InitializeComponent();
        }

        public string SoHDCT;
        private void frmInHD_Load(object sender, EventArgs e)
        {
            string query = "SELECT SANPHAM.TenSP, HOADON_CT.SoHDCT, HOADON_CT.SoLuong, HOADON.NgayHD, SANPHAM.DonGia, KHACHHANG.TenKH, SANPHAM.DonGia * HOADON_CT.SoLuong AS ThanhTien "+
                        " FROM SANPHAM INNER JOIN "+
                        " HOADON_CT ON SANPHAM.MaSP = HOADON_CT.MaSP INNER JOIN "+
                        " HOADON ON HOADON_CT.SoHD = HOADON.SoHD INNER JOIN "+
                        " KHACHHANG ON HOADON.MaKH = KHACHHANG.MaKH where HOADON_CT.SoHDCT= '" + SoHDCT +"'" ;

           SqlDataAdapter da = new SqlDataAdapter(query, XLBANG.cnnStr);
            try
            {
                DataTable tblHD = new DataTable();
                da.Fill(tblHD);
                rptInHD rpt = new rptInHD();
                rpt.SetDataSource(tblHD);
                rptvInHD.ReportSource = rpt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void rptvInHD_Load(object sender, EventArgs e)
        {

        }
    }
}
