namespace WebPaymentFineros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int PaymentId { get; set; }

        public int CustomerId { get; set; }

        [StringLength(16)]
        public string CCNumber { get; set; }

        [StringLength(10)]
        public string CCDate { get; set; }

        [StringLength(3)]
        public string CVV { get; set; }
        [StringLength(150)]
        public string CCNameSurname { get; set; }

        public double Price { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
