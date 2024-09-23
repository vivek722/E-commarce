using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Ef.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Ef.Core.Product
{
    public class Review
    {
        public int id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
