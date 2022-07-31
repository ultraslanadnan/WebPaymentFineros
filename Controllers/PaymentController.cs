using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPaymentFineros.Models;
namespace WebPaymentFineros.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PaymentController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {

        // GET api/values
        /// <summary>
        /// Get All Payments of Customers 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            using (ManagerDB db = new ManagerDB())
            {
                return db.Payment.OrderByDescending(x=> x.PaymentDate).ToList();
            }
        }
        // GET api/values
        /// <summary>
        /// Get  Payment By PaymentId 
        /// </summary>
        /// <returns></returns>
      
        [HttpGet]
        public Payment Get(int id)
        {
            using (ManagerDB db = new ManagerDB())
            {
                return db.Payment.Where(x => x.PaymentId == id).FirstOrDefault();
            }
        }

        // GET api/values
        /// <summary>
        /// Get All Payments of CC Number 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPaymentsByCCNumber")]
        public IEnumerable<Payment> GetPaymentsByCCNumber(string val)
        {
            using (ManagerDB db = new ManagerDB())
            {

                return db.Payment.Where(x => x.CCNumber == val).ToList();

            }
        }

        // GET api/values
        /// <summary>
        /// Get All Payments of CustomerId 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPaymentsByCustomerId")]
        public IEnumerable<Payment> GetPaymentsByCustomerId(int customerId)
        {
            using (ManagerDB db = new ManagerDB())
            {

                return db.Payment.Where(x => x.CustomerId == customerId).ToList();

            }
        }

        // POST api/values
        /// <summary>
        /// Create New Payment 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public String Create(Payment payment)
        {
            using (ManagerDB db = new ManagerDB())
            {
                if (payment == null)
                {
                    return "Please read Example Value";
                }
                try
                {
                    string result = "";
                    List<Customer> customer = new List<Customer>();
                    customer = db.Customer.Where(x => x.CustomerId == payment.CustomerId).ToList();
                    bool isCustomer = General.getBoolFromInt(customer.Count);
                    if (!General.NotGreatherThan(payment.Price,0))
                    {
                        result += "Price must be greather then 0  || ";
                    }
                    if (!General.NotGreatherThan(payment.CustomerId, 0))
                    {
                        result += "CustomerId must be greather then 0 || ";
                    }
                   
                    if (payment.CVV.Length != 3)
                    {
                        result += "CVV length must be 3 || ";
                    }
                    if (!isCustomer && payment.CustomerId > 0)
                    {
                        result += "CustomerId: " + payment.CustomerId + " not Found || ";
                    }
                    if (result.Length == 0)
                    {
                        db.Payment.Add(payment);
                        db.SaveChanges();
                        return "success";
                    }
                  
                    result = result.TrimEnd(' ');
                    result = result.TrimEnd('|');
                    result = result.TrimEnd('|');
                    return result;
                }
                catch (Exception ex)
                {
                   
                    return ex.ToString();
                    throw;
                }
            }
        }
    }
}
