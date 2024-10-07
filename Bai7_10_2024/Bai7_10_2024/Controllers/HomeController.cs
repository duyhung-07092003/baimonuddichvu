using Bai7_10_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai7_10_2024.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var nhanVien = new NhanVien();

            ViewBag.maNhanVienList = new List<SelectListItem>
            {
                new SelectListItem { Value = "01", Text = "Nhân viên 1" },
                new SelectListItem { Value = "02", Text = "Nhân viên 2" },
                new SelectListItem { Value = "03", Text = "Nhân viên 3" }
            };

            ViewBag.sanPhamList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Sản phẩm 1" },
                new SelectListItem { Value = "2", Text = "Sản phẩm 2" },
                new SelectListItem { Value = "3", Text = "Sản phẩm 3" }
            };

            ViewBag.queQuanList = new List<SelectListItem>
            {
                new SelectListItem { Value = "HaNoi", Text = "Hà Nội" },
                new SelectListItem { Value = "NamDinh", Text = "Nam Định" },
                new SelectListItem { Value = "HaiDuong", Text = "Hải Dương" },
                new SelectListItem { Value = "HaGiang", Text = "Hà Giang" }
            };

            return View(nhanVien);
        }


    }
}
