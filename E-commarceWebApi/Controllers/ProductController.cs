using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
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
                   // await _productService.Add(Roles);
                    return Ok(Roles);
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
