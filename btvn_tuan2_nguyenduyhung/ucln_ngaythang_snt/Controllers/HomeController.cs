using System;
using System.Web.Mvc;
using ucln_ngaythang_snt.Models;

namespace ucln_ngaythang_snt.Controllers
{
    public class HomeController : Controller
    {
        private readonly MayTinh _calculator = new();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateUCLN(int a, int b)
        {
            var result = _calculator.UCLN(a, b);
            ViewBag.UCLNResult = result;
            return View("Index");
        }

        [HttpPost]
        public ActionResult CalculateDays(int thang, int nam)
        {
            try
            {
                var result = _calculator.SoNgayTrongThang(thang, nam);
                ViewBag.DaysResult = result;
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewBag.DaysResult = "Tháng không hợp lệ";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult CalculateSumPrimes(string arr)
        {
            var numbers = Array.ConvertAll(arr.Split(','), int.Parse);
            var result = _calculator.TongSoNguyenTo(numbers);
            ViewBag.PrimesResult = result;
            return View("Index");
        }
    }
}
