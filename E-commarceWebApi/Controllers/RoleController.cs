using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _roleService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _roleService.SearchRoles(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddRoles")]
        public async Task<IActionResult> AddRoles([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (Roles != null)
                {
                    await _roleService.Add(Roles);
                    return Ok(Roles);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteRoles")]
        public async Task<IActionResult> DeleteRoles([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _roleService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles([FromForm] RoleDto RoleData)
        {
            if (ModelState.IsValid)
            {
                Role Roles = new Role();
                Roles.RoleName = RoleData.RoleName;
                if (RoleData != null)
                {
                    await _roleService.update(Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
