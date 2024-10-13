using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btvn_nguyenduyhung.Models
{
    public class hethuc
    {
        public hethuc() { 
        }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public hethuc(double a, double b, double c) {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}