using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.ProductData
{
    public class ProductImage : BaseEntityModel
    {
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public string ProductImag { get; set; }
    }
}
