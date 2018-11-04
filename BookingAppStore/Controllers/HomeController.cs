using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookingAppStore.Models;
using System.Threading.Tasks;


namespace BookingAppStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            return View(db.Books);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookID = id;

            ViewBag.BookName = (from book in db.Books
                               where book.Id == id
                               select book.Name).First();
            

            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {

            //purchase.PurchaseId = db.Purchases.Count() + 1;

            purchase.Date = DateTime.Now;

            db.Purchases.Add(purchase);

            db.SaveChanges();

            return Content($"thanks, {purchase.Name} for purchasing");
        }

        [HttpGet]
        public ActionResult SearchBook()
        {
            return View();
        }

        public ActionResult SearchBook(string Author, string BookName)
        {
            foreach (var book in db.Books)
            {
                if (book.Author == Author && book.Name == BookName)
                {
                    ViewBag.BookID = book.Id;
                    return Redirect("Buy/" + book.Id);
                }
            }

            return Content("Nothing found");
        }


    }
}