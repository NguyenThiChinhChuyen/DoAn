using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DACK_QLCH.Moduls
{
    class XLHOADONDH_CT:XLBANG
    {
        public XLHOADONDH_CT() : base("HOADONDH_CT") { }
        public XLHOADONDH_CT(string pQuery) : base("HOADONDH_CT", pQuery) { }
    }
}
