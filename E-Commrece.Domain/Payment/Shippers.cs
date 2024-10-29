using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class Shippers
    {
        public int id { get; set; }
        [MaxLength(20)]
        public int ShipperName { get; set; }
        [MaxLength(20)]
        public int Phone { get; set; }
        public Shipment Shipment { get; set; }


    }
}
