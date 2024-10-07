using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoNguyenTo.Models;

namespace HomeController.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new SoNguyenToModel());
        }

        [HttpPost]
        public ActionResult Index(SoNguyenToModel model, string danhSachSo)
        {
            var soList = danhSachSo.Split(',').Select(s =>{int.TryParse(s.Trim(), out int so);return so;}).Where(s => s > 0).ToList();

            model.danhSachSo = soList;
            model.tongSoNguyenTo = TinhTongSoNguyenTo(soList);

            return View(model);
        }

        private int TinhTongSoNguyenTo(List<int> soList)
        {
            return soList.Where(IsPrime).Sum();
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
