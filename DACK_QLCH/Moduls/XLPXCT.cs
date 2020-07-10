using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLPXCT:XLBANG
    {
        public XLPXCT() : base("PXCT") { }
        public XLPXCT(string pQuery) : base("PXCT", pQuery) { }
    }
}