using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _customerService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _customerService.SearchCustomer(SerchString);
            return Ok(Searchroles);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (Roles != null)
                {   
                    return Ok(Roles);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _customerService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (RoleData != null)
                {
                 //   await _customerService.update(Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
