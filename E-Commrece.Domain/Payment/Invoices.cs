using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class Invoices
    {
        public int id { get; set; }
        public int orderId { get; set; }
        [ForeignKey("orderId")]
        public Orders orders { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; }

        public ICollection<Payments> Payments { get; set; }

    }
}
