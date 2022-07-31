using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPaymentFineros.Models;
namespace WebPaymentFineros.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public string CheckUser(FormCollection formCollection)
        {
            try
            {
                //TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ManagerDB db = new ManagerDB();
                    List<Customer> customer = new List<Customer>();
                    customer = db.GetCustomer();
                    Customer customer1 = new Customer();
                
                    string userEmail = formCollection["txtEmail"];
                    string userPass = formCollection["txtPassword"];
                 

                    if (customer.Where(x=> x.Email==userEmail && x.Pw==userPass).ToList().Count == 1)
                    {
                        customer1 = customer.Where(x => x.Email == userEmail && x.Pw == userPass).FirstOrDefault();
                        string userDetail=customer1.FirstName + ";" + customer1.CustomerId;
                        FormsAuthentication.SetAuthCookie(userDetail, false);
                       //RedirectToAction("Index", "Home");
                        return "success";
                    }
                    else
                    {
                        return "Email or Password is incorrect";
                    }
                   
                    //var url = Url.RouteUrl("custom", new { controller = "Home", action = "Mesajlar" });
                    //return RedirectToAction("Index", "Home");

                }
                return "failed";


            }
            catch
            {
                return "failed";
            }

        }
    }

}