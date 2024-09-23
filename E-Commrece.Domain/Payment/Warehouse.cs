using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class Warehouse
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string WarehouseName { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
        public ICollection<Inventory> Inventory { get; set; }

    }
}
