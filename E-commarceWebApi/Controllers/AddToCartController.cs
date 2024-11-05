using AutoMapper;
using E_commarceWebApi.RequestModel;
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

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer(string? SerchString)
        {
            if (SerchString == null)
            {
                var CartAllProducts = await _addToCartService.GetAll();
                return Ok(CartAllProducts);
            }
            var SearchCartProducts = await _addToCartService.SearcAddToCart(SerchString);
            return Ok(SearchCartProducts);
        }
        [HttpPost("AddProductInCart")]
        public async Task<IActionResult> AddProductInCart([FromForm] AddToCartDto AddToCartDto)
        {
            if (ModelState.IsValid)
            {
                var Product = _mapper.Map<AddToCart>(AddToCartDto);
                if (Product != null)
                {
                    await _addToCartService.Add(Product);
                    return Ok(Product);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteProductInCart")]
        public async Task<IActionResult> DeleteProductInCart([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _addToCartService.Delete(id);
            return Ok("Cart Product Remove Successfully");
        }
        [HttpPut("UpdateProductInCart")]
        public async Task<IActionResult> UpdateProductInCart([FromForm] AddToCartDto AddToCartDto)
        {
            if (ModelState.IsValid)
            {
                var Product = _mapper.Map<AddToCart>(AddToCartDto);
                if (Product != null)
                {
                    await _addToCartService.update(Product);
                    return Ok(Product);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
