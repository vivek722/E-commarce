
using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface IAddToCartService : IGenricservice<AddToCart>
    {
        Task<List<AddToCart>> SearcAddToCart(string SearchString);
        Task<AddToCart> isProductInCart(int productId, string emailId);
        //Task<List<CartItemDto>> GetUserCartItems(int UserId);
    }
}
