using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebPaymentFineros.Models;

namespace WebPaymentFineros.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> Get()
        {
            using (ManagerDB db = new ManagerDB())
            {
                return db.Customer.OrderByDescending(x=> x.CustomerId).ToList();
            }
        }
        // GET api/values
        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <returns></returns>
        public Customer Get(int id)
        {
            using (ManagerDB db = new ManagerDB())
            {
                return db.Customer.Where(x => x.CustomerId == id).FirstOrDefault();
            }
        }
        // POST api/values
        /// <summary>
        /// Create New Customer 
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public string Create(Customer customer)
        {
            if (customer == null)
            {
                return "Please read Example Value";
            }
            using (ManagerDB db = new ManagerDB())
            {
                try
                {
                    if (db.Customer.Where(x => x.Email == customer.Email).ToList().Count > 0)
                    {
                        return "This Email is already exist";
                    }
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return "success";

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
