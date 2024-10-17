using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class OrderDetail : BaseEntityModel  
    {
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int productId { get; set; }
        public Products product { get; set; }
        public int Quantity { get; set; }
    }
}
