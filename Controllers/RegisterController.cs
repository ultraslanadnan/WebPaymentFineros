using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebPaymentFineros.Models;
namespace WebPaymentFineros.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        // POST: Register/Create
        [HttpPost]
        public string Create(FormCollection formCollection)
        {
            string result = "";
            try
            {
            //TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ManagerDB db = new ManagerDB();
                    Customer customer = new Customer();
                    customer.FirstName = formCollection["txtName"];
                    customer.LastName = formCollection["txtSurname"];
                    customer.Pw = formCollection["txtPassword"];
                    customer.Email = formCollection["txtEmail"];
                    customer.Phone = formCollection["txtPhone"];
                    customer.Age = Convert.ToInt32(formCollection["txtAge"]);
                    string strParams = JsonConvert.SerializeObject(customer);
                    string urlCreate =General.GetDomain() + "api/Customer";
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
            catch(Exception ex)
            {
                return ex.ToString();
            }
            return result;
        }

       
    }
}