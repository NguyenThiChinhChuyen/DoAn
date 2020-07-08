using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DACK_QLCH.Moduls
{
    class XLNHANVIEN : XLBANG
    {
        public XLNHANVIEN() : base("NHANVIEN") { }
        public XLNHANVIEN(string pQuery) : base("NHANVIEN", pQuery) { }
    }
}