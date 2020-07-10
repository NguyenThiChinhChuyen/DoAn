using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLPHIEUXUAT:XLBANG
    {
        public XLPHIEUXUAT() : base("PHIEUXUAT") { }
        public XLPHIEUXUAT(string pQuery) : base("PHIEUXUAT", pQuery) { }
    }
}