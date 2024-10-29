using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class AddToCartService : GenericService<AddToCart>, IAddToCartService
    {
        public AddToCartService(IGenricRepository<AddToCart> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<AddToCart>> SearcAddToCart(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
