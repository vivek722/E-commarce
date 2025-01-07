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
                    var CartAllProducts = await _addToCartService.GetByUserId(id);
                    return Ok(new DataResponseList() { Data = CartAllProducts, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchCartProducts = await _addToCartService.SearcAddToCart(SerchString);
                return Ok(new DataResponseList() { Data = SearchCartProducts, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddCartProduct")]
        public async Task<IActionResult> AddCartProduct([FromForm] AddToCartDto AddToCartDto)
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
        [HttpDelete("DeleteProductInCart/{id}")]
        public async Task<IActionResult> DeleteProductInCart(int id)
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
        public async Task<IActionResult> UpdateCartProduct([FromForm] AddToCartDto AddToCartDto)
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Cart Product Not Updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("isProductInCart")]
        public async Task<IActionResult> isProductInCart(int ProductId,string emailId)
        {
            try
            {
                var AddToCartData = await _addToCartService.isProductInCart(ProductId, emailId);
                if (AddToCartData != null)
                {
                    return Ok(new DataResponseList() { Data = AddToCartData, Status = StatusCodes.Status200OK, Message = "Products is alredy in cart" });
                }
                return Ok(new DataResponseList() { Data = AddToCartData, Status = StatusCodes.Status200OK, Message = "Empty" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });

            }
        }
    }
}
