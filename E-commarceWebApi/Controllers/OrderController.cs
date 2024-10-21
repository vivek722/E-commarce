using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _orderService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _orderService.SearchOrder(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (Roles != null)
                {
                   // await _orderService.Add(Roles);
                    return Ok(Roles);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _orderService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (RoleData != null)
                {
                   // await _orderService.update(Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
