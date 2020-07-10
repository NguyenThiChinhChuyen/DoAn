using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DACK_QLCH.Moduls
{
    class XLPNCT:XLBANG
    {
        public XLPNCT() : base("PNCT") { }
        public XLPNCT(string pQuery) : base("PNCT", pQuery) { }
    }
}