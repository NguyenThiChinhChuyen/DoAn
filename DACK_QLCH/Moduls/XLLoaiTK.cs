﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DACK_QLCH.Moduls
{
        class XLLOAITK : XLBANG
        {
            public XLLOAITK() : base("LOAITK") { }
            public XLLOAITK(string pQuery) : base("LOAITK", pQuery) { }
        }
 
}