using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ucln.Models;

namespace ucln.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        int uocchung(int a, int b)
        {
            if(b== 0)
            {
                return a;
            }
            return uocchung(b, a%b);
        }

        public ActionResult DuyHung(uocchunglonnhat uoc)
        {
            int a = uoc.A;
            int b = uoc.B;
            int s = uocchung(a, b);
            ViewBag.s = s;
            return View("Index",uoc);
        }

        
    }
}