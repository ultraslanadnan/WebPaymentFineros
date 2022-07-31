using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebPaymentFineros.Models
{
    public partial class ManagerDB : DbContext
    {
        public ManagerDB()
            : base("name=ManagerDB")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<MyProduct> MyProduct { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers = Customer.ToList();
            return customers;
        }
        public MyProduct GetProductById(int id)
        {
            MyProduct singleproduct = new MyProduct();
            singleproduct = MyProduct.Where(x=> x.ProductId==id).FirstOrDefault();
            return singleproduct;
        }
        public List<Payment> GetPayment()
        {
            List<Payment> payments = new List<Payment>();
            payments = Payment.ToList();
            return payments;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyProduct>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CCNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CCDate)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CVV)
                .IsUnicode(false);
            modelBuilder.Entity<Payment>()
               .Property(e => e.CCNameSurname)
               .IsUnicode(false);
        }
    }
}
