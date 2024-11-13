using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}