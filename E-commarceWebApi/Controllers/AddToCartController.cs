using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddToCartController : Controller
    {
        private readonly IAddToCartService _addToCartService;
        private readonly IMapper _mapper;
        public AddToCartController(IAddToCartService addToCartService, IMapper mapper)
        {
            _addToCartService = addToCartService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCartProducts/{id}")]
        public async Task<IActionResult> GetAllCartProducts(int id, string? SerchString)
        {
            try
            {
                if (SerchString == null)
                {
                    var CartAllProducts = await _addToCartService.GetUserCartItems(id);
                    return Ok(CartAllProducts);
                }
                var SearchCartProducts = await _addToCartService.SearcAddToCart(SerchString);
                return Ok(SearchCartProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddCartProduct")]
        public async Task<IActionResult> AddCartProduct(AddToCartDto AddToCartDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Product = _mapper.Map<AddToCart>(AddToCartDto);
                    if (Product != null)
                    {
                        await _addToCartService.Add(Product);
                        return Ok(new Response { Status = "Success", Message = "Product Add On Your Cart" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Product is not add On Your Cart" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteProductInCart")]
        public async Task<IActionResult> DeleteProductInCart( int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _addToCartService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Cart Product Remove Successfully" });
                }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateCartProduct")]
        public async Task<IActionResult> UpdateCartProduct(AddToCartDto AddToCartDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Product = _mapper.Map<AddToCart>(AddToCartDto);
                    if (Product != null)
                    {
                        await _addToCartService.update(Product);
                        return Ok(new Response { Status = "Success", Message = "Your Cart Product Updated" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Cart Product Not Updated"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("isProductInCart")]
        public async Task<IActionResult> isProductInCart(int ProductId, int UserId)
        {
            var AddToCartData = await _addToCartService.isProductInCart(ProductId, UserId);
            if (AddToCartData != null)
            {
                return Ok(AddToCartData);
            }
            return Ok(AddToCartData);
        }
    }
}
