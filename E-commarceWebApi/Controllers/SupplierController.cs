using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;

        public SupplierController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _supplierService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _supplierService.SearchSupplier(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (Roles != null)
                {
                    await _supplierService.Add(Roles);
                    return Ok(Roles);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _supplierService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (RoleData != null)
                {
                    await _supplierService.update(Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
