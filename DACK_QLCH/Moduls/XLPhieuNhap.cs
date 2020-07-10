using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLPHIEUNHAP:XLBANG
    {
        public XLPHIEUNHAP() : base("PHIEUNHAP") { }
        public XLPHIEUNHAP(string pQuery) : base("PHIEUNHAP", pQuery) { }
    }
}