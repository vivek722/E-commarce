﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class ProductSupplier
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}