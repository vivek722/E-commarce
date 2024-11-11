using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WishlistController : Controller
    {
        private readonly IWishListService _wishlistService;
        private readonly IMapper _mapper;
        public WishlistController(IWishListService wishListService, IMapper mapper)
        {
            _wishlistService = wishListService;
            _mapper = mapper;
        }

        [HttpGet("GetAllWishlistProducts")]
        public async Task<IActionResult> GetAllWishlistProducts(string? SerchString)
        {
            if (SerchString == null)
            {
                var CartAllProducts = await _wishlistService.GetAll();
                return Ok(CartAllProducts);
            }
            var SearchCartProducts = await _wishlistService.SearcWishlist(SerchString);
            return Ok(SearchCartProducts);
        }
        [HttpPost("AddWishlistProduct")]
        public async Task<IActionResult> AddWishlistProduct(WishListDto WishListDto)
        {
            if (ModelState.IsValid)
            {
                var Product = _mapper.Map<Wishlist>(WishListDto);
                if (Product != null)
                {
                    await _wishlistService.Add(Product);
                    return Ok(Product);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteWishlistProduct")]
        public async Task<IActionResult> DeleteWishlistProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _wishlistService.Delete(id);
            return Ok("Cart Product Remove Successfully");
        }
        [HttpPut("UpdateWishlistProduct")]
        public async Task<IActionResult> UpdateWishlistProduct( WishListDto WishListDto)
        {
            if (ModelState.IsValid)
            {
                var Product = _mapper.Map<Wishlist>(WishListDto);
                if (Product != null)
                {
                    await _wishlistService.update(Product);
                    return Ok(Product);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
