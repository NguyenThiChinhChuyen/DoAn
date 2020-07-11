using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLPHIEUXUAT_CT:XLBANG
    {
        public XLPHIEUXUAT_CT() : base("PHIEUXUAT_CT") { }
        public XLPHIEUXUAT_CT(string pQuery) : base("PHIEUXUAT_CT", pQuery) { }
    }
}