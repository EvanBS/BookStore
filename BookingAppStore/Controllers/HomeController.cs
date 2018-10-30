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
            var books = db.Books;

            ViewBag.Books = books;

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookID = id;

            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {

            purchase.PurchaseId = db.Purchases.Count() + 1;

            purchase.Date = DateTime.Now;

            db.Purchases.Add(purchase);

            db.SaveChanges();

            return Content($"thanks, {purchase.Name} for purchasing");
        }
    }
}