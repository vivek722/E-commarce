
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
        private IAddToCartRepository _repository;
        public AddToCartService(IAddToCartRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public Task<AddToCart> isProductInCart(int productId, string emailId)
        {
           return _repository.isProductInCart(productId, emailId);
        }

        public Task<List<AddToCart>> SearcAddToCart(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
