using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DACK_QLCH.Moduls
{
    class XLPHIEUNHAP_CT : XLBANG
    {
        public XLPHIEUNHAP_CT() : base("PHIEUNHAP_CT") { }
        public XLPHIEUNHAP_CT(string pQuery) : base("PHIEUNHAP_CT", pQuery) { }
    }
}