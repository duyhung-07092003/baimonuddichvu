using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoNguyenTo.Models
{
    public class SoNguyenToModel
    {
        public List<int> danhSachSo { get; set; } = new List<int>();
        public int tongSoNguyenTo { get; set; } = 0;
    }
}