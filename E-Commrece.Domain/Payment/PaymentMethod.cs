﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class PaymentMethod
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string MethodName { get; set; }
        public ICollection<CustomerPayment> CustomerPayment { get; set; }
    }
}
