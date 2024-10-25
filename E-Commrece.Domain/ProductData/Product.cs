﻿using E_commerce.Ef.Core.User;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Products : BaseEntityModel
    {
        [MaxLength(100)]
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductOrignalprice { get; set; }
        public decimal ProductActualprice { get; set; }
        public string ProductImag { get; set; }
        public DateTime CrateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int supplierId { get; set; }
        [ForeignKey("supplierId")]
        public Supplier supplier { get; set; }
        public int InventoryId { get; set; }
        [ForeignKey("supplierId")]
        public Inventory Inventory { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
        public ICollection<Discount> Discount { get; set; }
        public ICollection<Inventory> Inventorys{ get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
