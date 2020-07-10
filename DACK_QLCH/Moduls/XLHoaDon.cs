using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLHOADON:XLBANG
    {
        public XLHOADON() : base("HOADON") { }
        public XLHOADON(string pQuery) : base("HOADON", pQuery) { }
    }
}