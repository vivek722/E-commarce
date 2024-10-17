using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.productData
{
    public class ProductService : GenericService<Products>, IProductService
    {
        public ProductService(IGenricRepository<Products> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<Products>> SearchProduct(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
