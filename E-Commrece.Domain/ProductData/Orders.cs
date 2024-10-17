using E_commerce.Ef.Core.Payment;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Orders : BaseEntityModel
    {
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public ICollection<Invoices> Invoices { get; set; }

        public ICollection<Shipment> Shipment { get; set; }


    }
}
