using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.FireBaseSevice;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFireBaseUploadImageService _imageService;
        private readonly IMapper _mapper;
        public ProductController(ProductService productService, IMapper mapper, IFireBaseUploadImageService imageService)
        {
            _productService = productService;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(string? SerchString)
        {
            if (SerchString == null)
            {
                var products = await _productService.GetAll();
                return Ok(products);
            }
            var Searchroles = await _productService.SearchProduct(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto ProductDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Products>(ProductDto);
                if (ProductDto.ProductImag != null)
                {
                    foreach (var item in ProductDto.ProductImag)
                    {
                        var file = Guid.NewGuid().ToString() + "-" + item.FileName;
                        var path = Path.Combine(Path.GetTempPath(), file);
                        var folder = "Product-Images";
                        using (var strem = new FileStream(path, FileMode.Create))
                        {
                            await item.CopyToAsync(strem);
                        }
                        var url = await _imageService.FireBaseUploadImageAsync(file, path, folder);
                        product.ProductImag += url;
                    }
                }
                product.CrateAt = DateTime.Now;
                product.UpdateAt = null;
                if (product != null)
                {
                  await _productService.Add(product);
                  return Ok(product);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is Not 0 or  Not Lessthen 0");
            }
            await _productService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductDto Product)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Products>(Product);
                if (product != null)
                {
                    await _productService.update(product);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
