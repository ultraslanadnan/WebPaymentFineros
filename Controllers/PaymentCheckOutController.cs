using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPaymentFineros.Models;
namespace WebPaymentFineros.Controllers
{
    public class PaymentCheckOutController : Controller
    {
        // GET: PaymentCheckOut
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Create(FormCollection formCollection)
        {
            string result = "";
            try
            {
                //TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (!User.Identity.IsAuthenticated)
                    {
                        return "login";
                    }
                    ManagerDB db = new ManagerDB();
                    Payment payment = new Payment();
                    payment.CVV = formCollection["txtCVV"];
                    payment.CCNumber = formCollection["txtCCNumber"];
                    payment.CCDate = formCollection["selM"] + "/" + formCollection["selY"];
                    payment.CCNameSurname = formCollection["txtCCNameSurname"];
                    int proId = Convert.ToInt32(formCollection["hidProductId"]);
                    MyProduct pro = db.MyProduct.Where(x => x.ProductId == proId).FirstOrDefault();
                    payment.Price = pro.Price;
                    payment.PaymentDate = DateTime.Now;
                    //payment.Price = 200;
                    payment.CustomerId =Convert.ToInt32(User.Identity.Name.ToString().Split(';')[1].ToString());
                    string strParams = JsonConvert.SerializeObject(payment);
                    string urlCreate =General.GetDomain() + "api/Payment";
                    string responseFromServer = General.SendJSonData(urlCreate, strParams).Replace("\"", "");
                    if (responseFromServer == "success")
                    {
                        //RedirectToAction("Login", "Home");
                        return responseFromServer;
                    }
                    else
                    {
                        return responseFromServer;
                    }
                }



            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return result;
        }
    }
}