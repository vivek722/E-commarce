using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class WishListService : GenericService<Wishlist> , IWishListService
    {
        public WishListService(IGenricRepository<Wishlist> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<Wishlist>> SearcWishlist(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
