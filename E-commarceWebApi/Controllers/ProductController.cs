using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.FireBaseSevice;
using E_Commrece.Domain.services.Payment;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        private readonly IFireBaseUploadImageService _imageService;
        private readonly IMapper _mapper;
        public ProductController(ProductService productService, IMapper mapper, IFireBaseUploadImageService imageService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _productService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _productService.SearchProduct(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (Roles != null)
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
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _productService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (RoleData != null)
                {
                   // await _productService.update(Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
