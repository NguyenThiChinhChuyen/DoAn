﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DACK_QLCH.Moduls
{
    class XLSANPHAM:XLBANG
    {
        public XLSANPHAM() : base("SANPHAM") { }
        public XLSANPHAM(string pQuery) : base("SANPHAM", pQuery) { }
    }
}