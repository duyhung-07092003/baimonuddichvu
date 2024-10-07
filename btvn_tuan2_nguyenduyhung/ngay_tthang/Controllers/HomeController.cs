using ngay_tthang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ngay_tthang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DuyHung(dmy a)
        {
            if (ModelState.IsValid)
            {
                
                if (a.Month < 1 || a.Month > 12)
                {
                    ModelState.AddModelError("Month", "Tháng phải nằm trong khoảng từ 1 đến 12.");
                }
                else if (a.Year < 1)
                {
                    ModelState.AddModelError("Year", "Năm phải là một giá trị dương.");
                }
                else
                {

                    int daysInMonth = DateTime.DaysInMonth(a.Year, a.Month);
                    ViewBag.DaysInMonth = daysInMonth;
                }
            }

            return View(a);

        }

        
    }
}