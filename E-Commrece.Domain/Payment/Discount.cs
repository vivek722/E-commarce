using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Discount
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products product { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
