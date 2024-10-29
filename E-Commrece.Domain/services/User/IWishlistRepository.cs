using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface IWishlistRepository : IGenricRepository<Wishlist>
    {
        Task<List<Wishlist>> SearcWishlist(string SearchString);
    }
}
