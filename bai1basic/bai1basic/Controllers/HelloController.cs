using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai1basic.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        String name = "hung";
        public String Index()
        {
            return name;
        }
    }
}