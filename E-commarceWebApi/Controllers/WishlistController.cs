using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
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
            try
            {
                if (SerchString == null)
                {
                    var CartAllProducts = await _wishlistService.GetAll();
                    return Ok(new DataResponseList() { Data = CartAllProducts, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchCartProducts = await _wishlistService.SearcWishlist(SerchString);
                return Ok(new DataResponseList() { Data = SearchCartProducts, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetWishlistById/{id}")]
        public async Task<IActionResult> GetWishlistById(int id)
        {
            try
            {
                var UserGetWishlistByIdByid = await _wishlistService.GetById(id);
                return Ok(new DataResponseList() { Data = UserGetWishlistByIdByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddWishlistProduct")]
        public async Task<IActionResult> AddWishlistProduct([FromForm] WishListDto WishListDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Product = _mapper.Map<Wishlist>(WishListDto);
                    if (Product != null)
                    {
                        await _wishlistService.Add(Product);
                        return Ok(new Response { Status = "Success", Message = "Product Add In Wishlist" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = " Product Not Add In Wishlist" });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteWishlistProduct")]
        public async Task<IActionResult> DeleteWishlistProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _wishlistService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Product Remove From Wishlist" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateWishlistProduct")]
        public async Task<IActionResult> UpdateWishlistProduct([FromForm] WishListDto WishListDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Product = _mapper.Map<Wishlist>(WishListDto);
                    if (Product != null)
                    {
                        await _wishlistService.update(Product);
                        return Ok(new Response { Status = "Success", Message = "Wishlist Data Updated" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Wishlist not updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("isProductInWishlist")]
        public async Task<IActionResult> isProductInWishlist(int ProductId, int UserId)
        {
            try
            {
                var wishlistData = await _wishlistService.isProductInWishlist(ProductId, UserId);
                if (wishlistData != null)
                {
                    return Ok(new DataResponseList() { Data = wishlistData, Status = StatusCodes.Status200OK, Message = "Products is alredy in wishlist" });
                }
                return Ok(new DataResponseList() { Data = wishlistData, Status = StatusCodes.Status200OK, Message = "Empty" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });

            }
        }
    }
}
