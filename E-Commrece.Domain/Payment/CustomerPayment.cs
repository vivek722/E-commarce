﻿using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class CustomerPayment
    {
        public int id { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int paymentMethodId { get; set; }

        [ForeignKey("paymentMethodId")]
        public PaymentMethod  paymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}