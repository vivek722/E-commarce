using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.FireBaseSevice;
using E_Commrece.Domain.ProductData;
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
            try
            {
                if (SerchString == null)
                {
                    var products = await _productService.GetAll();
                    return Ok(products);
                }
                var Searchroles = await _productService.SearchProduct(SerchString);
                return Ok(Searchroles);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto ProductDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = _mapper.Map<Products>(ProductDto);

                    product.ProductImage = product.ProductImage ?? new List<ProductImage>();

                    if (ProductDto.ProductImag != null)
                    {
                        foreach (var item in ProductDto.ProductImag)
                        {
                            var file = Guid.NewGuid().ToString() + "-" + item.FileName;
                            var path = Path.Combine(Path.GetTempPath(), file);
                            var folder = "Product-Images";

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await item.CopyToAsync(stream);
                            }

                            var url = await _imageService.FireBaseUploadImageAsync(file, path, folder);


                            product.ProductImage.Add(new ProductImage { ProductImag = url });
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

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Product Is Not Add" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Is Not 0 or  Not Lessthen 0" });
                }
                await _productService.Delete(id);
                return Ok("Role Deleted Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto Product)
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
