using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DACK_QLCH.Moduls
{
    class XLHOADON_CT:XLBANG
    {
        public XLHOADON_CT() : base("HOADON_CT") { }
        public XLHOADON_CT(string pQuery) : base("HOADON_CT", pQuery) { }
    }
}