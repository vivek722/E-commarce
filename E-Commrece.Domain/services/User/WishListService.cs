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
        private readonly IWishlistRepository _wishlistRepository;
        public WishListService(IWishlistRepository wishlistRepository) : base(wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public Task<Wishlist> isProductInWishlist(int productId, int UserId)
        {
            return _wishlistRepository.isProductInWishlist(productId, UserId);
        }

        public Task<List<Wishlist>> SearcWishlist(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
