using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class Shipment
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrdersId")]
        public Orders Orders { get; set; }

        public int ShipperId { get; set; }

        [ForeignKey("ShippersId")]
        public Shippers Shippers { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
