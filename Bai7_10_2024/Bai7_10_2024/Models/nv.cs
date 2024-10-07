using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai7_10_2024.Models
{
    public class NhanVien
    {
        public String maNhanVien { get; set; }
        public String tenNhanVien { get; set; }
        public String diaChi { get; set; }
        public String email { get; set; }
        public String gioiTinh { get; set; } 
        public bool trangThaiHoatDong { get; set; }  
        public string matKhau { get; set; } 
        public List<string> sanPhamChon { get; set; }
        public string queQuan { get; set; }
    }
}
