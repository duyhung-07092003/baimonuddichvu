using giaiptbac2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giaiptbac2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DuyHung(giaipt gpt)
        {
            double a = gpt.A;
            double b = gpt.B;
            double c = gpt.C;
            String s = "";
            double delta = b * b - 4 * a * c;

            if (delta > 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                s = $"x1 = {x1:F2}, x2 = {x2:F2}";
            }
            else if (delta == 0)
            {
                double x = (-b) / (2 * a);
                s = $"x1 = x2 = {x:F2}";
            }
            else
            {
                s = "Phương trình vô nghiệm!";
            }

            ViewBag.s = s;
            return View("Index", gpt);
        }
        public ActionResult Reset()
        {
            return RedirectToAction("Index");

        }
    }
    
}