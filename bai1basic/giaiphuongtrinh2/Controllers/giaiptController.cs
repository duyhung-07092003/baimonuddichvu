using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giaiphuongtrinh2.Controllers
{
    public class giaiptController : Controller
    {
        
        // GET: giaipt
        public string hung(double a, double b, double c)
        {
            double del = b * b - 4 * a * c;
            if(a != 0)
            {
                if (del < 0)
                {
                    return $"<h1 style=\"color: blue;\">Phương trình {a}x<sup>2</sup> + {b}x + {c} vô nghiệm !!!</h1>";
                }
                else if (del == 0)
                {
                    return $"<h1 style=\"color: blue;\">Phương trình {a}x<sup>2</sup> + {b}x + {c} có nghiệm kép x ={(-b) / (2 * a)}</h1>";
                }
                else
                {
                    return $"<h1 style=\"color: blue;\">Phương trình {a}x<sup>2</sup> + {b}x + {c} có nghiệm: <br> x<sub>1</sub> = {Math.Round((-b + Math.Sqrt(del)) / (2 * a),2)} <br> x<sub>2</sub> =  {Math.Round((-b - Math.Sqrt(del)) / (2 * a),2)}</h1>";
                }
            }
            else
            {
                return "Hệ Phương Trình Không Phải Phương Trình Bậc 2 !!!";
            }
        }
    }
}