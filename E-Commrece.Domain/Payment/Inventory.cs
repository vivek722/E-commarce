using E_commerce.Ef.Core.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Inventory
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products product { get; set; }
        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }

    }
}
