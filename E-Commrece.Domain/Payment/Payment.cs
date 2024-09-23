using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Payment
{
    public class Payments
    {
        public int id { get; set; }

        public int InvoicesId { get; set; }
        [ForeignKey("InvoicesId")]
        public Invoices invoices { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PaymentAmount { get; set; }
    }
}
