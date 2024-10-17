using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Supplier : BaseEntityModel
    {
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}
