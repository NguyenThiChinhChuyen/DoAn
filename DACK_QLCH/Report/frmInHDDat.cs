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
    public partial class frmInHDDAT : Form
    {
        public frmInHDDAT()
        {
            InitializeComponent();
        }
        public string SoHDDH;
        private void rptvInHDDAT_Load(object sender, EventArgs e)
        {

        }

        private void frmInHDDAT_Load(object sender, EventArgs e)
        {
            string query = "SELECT HOADONDH_CT.SoHDDH,HOADONDH_CT.SoLuong * SANPHAM.DonGia as ThanhTien, HOADONDH_CT.SoLuong, SANPHAM.DonGia, HOADONDH_CT.SDTGH, HOADONDH_CT.DiaChiGH, HOADONDH_CT.TenKHGH, HOADONDH_CT.NgayGH," +
             " HOADONDH_CT.NgayHDDH, SANPHAM.TenSP" +
             " FROM HOADONDH_CT INNER JOIN" +
             " SANPHAM ON HOADONDH_CT.MaSP = SANPHAM.MaSP where HOADONDH_CT.SoHDDH= '" + SoHDDH + "'";

            SqlDataAdapter da = new SqlDataAdapter(query, XLBANG.cnnStr);
            try
            {
                DataTable tblThanhToan = new DataTable();
                da.Fill(tblThanhToan);
                rptInHDDat rpt = new rptInHDDat();
                rpt.SetDataSource(tblThanhToan);
                rptvInHDDAT.ReportSource = rpt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
