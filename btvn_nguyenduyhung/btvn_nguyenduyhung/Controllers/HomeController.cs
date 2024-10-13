using btvn_nguyenduyhung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btvn_nguyenduyhung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult nhapdl()
        {
            return View();
        }

        public bool kthh(int x)
        {
            int i = 2, tong = 1;
            while (i * i < x)
            {
                if (x % i == 0)
                {
                    tong += i + x / i;

                }
                i++;
            }
            if (i * i == x)
            {
                tong += i;
            }
            if (tong == x)
            {
                return true;
            }
            return false;

        }

        public ActionResult sohh(int n)
        {
            ViewBag.kq = "";
            for (int i = 6; i < n; i++)
            {
                if (kthh(i))
                {
                    ViewBag.kq += i.ToString() + " ";
                }
            }
            return Content(ViewBag.kq);
        }

        bool ktcp(int x)
        {
            if(Math.Pow((int)Math.Sqrt(x),2) == x)
            {
                return true;
            }
            return false;
        }
        public ActionResult socp(string s)
        {
            ViewBag.kq = "";
            if (!string.IsNullOrEmpty(s) && s.IndexOf(",") > -1)
            {
                string[] str = s.Split(',');
                var arr = Array.ConvertAll(str, int.Parse);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (ktcp(arr[i])) {
                        ViewBag.kq += arr[i].ToString() + "";
                    }
                    else
                    {
                        ViewBag.kq = "Ban nhap khogn dung dinh dang";
                    }
                }
            }
            return Content(ViewBag.kq);

        }

        public ActionResult giaiptbac2(hethuc ht)
        {
            ViewBag.kq = "Phương trình đã cho ";
            if (ht != null)
            {
                if (ht.a == 0)
                {
                    ViewBag.kq += "không phải phương trình bậc 2 một ẩn";
                }
                else
                {
                    double d = ht.b * ht.b - 4 * ht.a * ht.c;
                    if (d < 0)
                    {
                        ViewBag.kq += "vô nghiệm";
                    }
                    else if (d == 0)
                    {
                        ViewBag.kq += "có ngiệm kép x = " + (-ht.b / (2 * ht.a));
                    }
                    else
                    {
                        double x1 = (-ht.b - Math.Sqrt(d)) / (2 * ht.a);
                        double x2 = (-ht.b + Math.Sqrt(d)) / (2 * ht.a);
                        ViewBag.kq += " có 2 nghiệm phân biệt:<br> x<sub>1</sub> = " + x1 + "<br> x<sub>2</sub> = " + x2;

                    }
                }
            }
            return View();
        }




    }
}