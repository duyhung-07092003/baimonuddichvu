using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class BooksController : Controller
    {
        private BookEntities1 db = new BookEntities1();

        // GET: Books
        public ActionResult Index()
        {
            
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            var sumtttgAnh = db.Books.Where(b => b.Author.AuthorName.Contains("Anh")).Sum(b => b.Price);
            ViewBag.sumtttgAnh = sumtttgAnh;
            // var kt = db.Books.Any(b => b.Price > 200000);
            // string thongbao = "";
            //if(kt == true) thongbao = " co";
            // else thongbao = " khong";
            // ViewBag.thongbao = thongbao;
            var kt = db.Books.All(b => b.Price > 200000);
             string thongbao = "";
            if(kt == true) thongbao = "Tat ca cac cuon sach gia lon hon 20000";
            else thongbao = " Tồn tại cuốn sách giá <= 200000";
             ViewBag.thongbao = thongbao;

            var countbooks = db.Books.Count(b => b.Author.AuthorName.Contains("Anh"));
            ViewBag.countbooks = countbooks;
            return View(books.ToList());
        }
        public ActionResult DSMaxgia()
        {

            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            var Maxgia = db.Books.Max(b => b.Price);
            books = books.Where(b => b.Price == Maxgia);

            return View(books.ToList());
        }
        public ActionResult Sachdatnhat()
        {
            // lấy 2 quyển đắt nhất
           // var books = db.Books.Include(b => b.Author).Include(b => b.Category);
          //  books = books.OrderByDescending(b=>b.Price).Take(2);
          // lấy quyển đắt thứ 2 thứ 3 , skip quyển 1
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.OrderByDescending(b => b.Price).Skip(1).Take(2);
            return View(books.ToList());
        }
        public ActionResult CheapBook()
        {

            var books = db.Books.OrderBy(b => b.Price).ToList();
            var cheapbook = books.TakeWhile(b => b.Price < 20000);


            return View(cheapbook.ToList());
        }
        public ActionResult Expensivebook()
        {

            var books = db.Books.OrderBy(b => b.Price).ToList();
            var expensive = books.SkipWhile(b => b.Price < 20000);


            return View(expensive.ToList());
        }
        public ActionResult GroupBookCategory()
        {
            var gbooks = db.Books
                .GroupBy(b => b.Category.CategoryName)
                .Select(g => new GroupBookCategory { CategoryName = g.Key, Bookcount = g.Count() });
            return View(gbooks.ToList());

             
        }
        public ActionResult TK(string searchString)
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            if(!string.IsNullOrEmpty(searchString))
            {
                searchString=searchString.Trim().ToLower();
                books=books.Where(b=>b.Title.Trim().ToLower().Contains( searchString) || b.Description.Contains(searchString));
            }    
            return View(books.ToList());
        }
        public ActionResult SelectPrice()
        {
            var books = db.Books.Select(b => new BookViewModel {Title = b.Title, Price = b.Price}) ;

            return View(books.ToList());
        }
        public ActionResult Sapxeptheoanphab()
        {
            // dùng orderby or orderbydecresing
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.OrderBy(b => b.Title);
            return View(books.ToList());
        }
        public ActionResult SachGiaLon20()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.Where(b => b.Price > 20000 && b.Author.AuthorName.Contains("Anh"));
            return View(books.ToList());
        }
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
