using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btvn_19_10_2024_NguyenDuyHung.Models;

namespace btvn_19_10_2024_NguyenDuyHung.Controllers
{
    public class usersController : Controller
    {

        public static List<User> users = new List<User>
        {
            new User {tk = "admin",mk = "admin"}
        };
        // GET: users
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult check(User user)
        {

            var kt = users.Find(u => u.tk == user.tk && u.mk == user.mk);
            if (kt != null)
            {
                return RedirectToAction("Welcome"); 
            }
            else
            {
                ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View("Index", user); 
            }
        }

        // Trang chào mừng
        public ActionResult Welcome()
        {
            return Content("Chào mừng bạn đã đăng nhập thành công!");
        }
    }
}