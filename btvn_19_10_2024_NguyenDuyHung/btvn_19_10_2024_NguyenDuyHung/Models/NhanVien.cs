using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace btvn_19_10_2024_NguyenDuyHung.Models
{
    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage = "Vui Long NHap dung dinh dang")]
        [StringLength(10, ErrorMessage = "Phai co it nhat 4 ky tu nhieu nhat 10", MinimumLength = 4)]
        public string maNhanVien { get; set; }

        public string hoTen { get; set; }

        public DateTime ngaySinh { get; set; }

        public string gioiTinh { get; set; }

        public string sdt  { get; set; }

        public double heSoLuong { get; set; }

        public double luong { get; set; }

        public string tenPhong { get; set; }

    }
}