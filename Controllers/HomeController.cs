using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPaymentFineros.Models;
namespace WebPaymentFineros.Controllers
{
    public class HomeController : Controller
    {
        ManagerDB db = new ManagerDB();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.MyProduct);
        }
        public ActionResult Payment()
        {
            return View(db.Payment.OrderByDescending(x=> x.PaymentDate));
        }
        public ActionResult Customer()
        {
            return View(db.Customer.OrderByDescending(x=> x.CustomerId));
        }
        public ActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult PaymentCheckOut(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
    }
}