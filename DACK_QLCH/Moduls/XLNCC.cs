﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DACK_QLCH.Moduls
{
    class XLNCC:XLBANG
    {
        public XLNCC() : base("NCC") { }
        public XLNCC(string pQuery) : base("NCC", pQuery) { }
    }
}