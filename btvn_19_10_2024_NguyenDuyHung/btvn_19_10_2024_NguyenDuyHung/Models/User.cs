using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace btvn_19_10_2024_NguyenDuyHung.Models
{
    public class User
    {
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Nhap sai kich thuoc !!")]
        [Required]
        public string tk { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "mat khau it nhat phai co 4 ki tu")]
        public string mk { get; set; }
       
    }
}