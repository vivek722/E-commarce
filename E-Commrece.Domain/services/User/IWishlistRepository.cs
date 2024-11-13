using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commrece.Domain.services.User
{
    public interface IWishlistRepository : IGenricRepository<Wishlist>
    {
        Task<List<Wishlist>> SearcWishlist(string SearchString);

        Task<Wishlist> isProductInWishlist(int productId ,int UserId);
    }
}
