using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DACK_QLCH.Moduls
{
    class XLKHACHHANG:XLBANG
    {

        public XLKHACHHANG() : base("KHACHHANG") { }
        public XLKHACHHANG(string pQuery) : base("KHACHHANG", pQuery) { }
    }
}
