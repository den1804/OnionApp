using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;

namespace OnionApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        private IOrder _order;
        public HomeController(IBookRepository r, IOrder o)
        {
            _repo = r;
            _order = o;
        }
        public ActionResult Index()
        {
            var books = _repo.GetBookList();
            return View();
        }
        public ActionResult Buy(int id)
        {
            Book book = _repo.GetBook(id);
            _order.MakeOrder(book);
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }

    }
}