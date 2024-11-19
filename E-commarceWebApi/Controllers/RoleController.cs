using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
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
            try
            {
                if (SerchString == null)
                {
                    var Allroles = await _roleService.GetAll();
                    return Ok(new DataResponseList() { Data = Allroles, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var Searchroles = await _roleService.SearchRoles(SerchString);
                return Ok(new DataResponseList() { Data = Searchroles, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetRoleById/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var RoleDataByid = await _roleService.GetById(id);
                return Ok(new DataResponseList() { Data = RoleDataByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddRoles")]
        public async Task<IActionResult> AddRoles([FromForm] RoleDto RoleData)
        {
            try
            {
                var roleExists = await _roleService.SearchRoles(RoleData.RoleName);
                if (roleExists != null)
                {
                    return Ok(new Response { Status = "Error", Message = "Role Already Have Exists!" });
                }
                if (ModelState.IsValid)
                {
                    Role Roles = new Role();
                    Roles.RoleName = RoleData.RoleName;
                    if (Roles != null)
                    {
                        await _roleService.Add(Roles);
                        return Ok(new Response { Status = "Success", Message = "Role Add Successfully !" });
                    }
                }
               return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role Not Created" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
            [HttpDelete("DeleteRoles")]
        public async Task<IActionResult> DeleteRoles([FromForm] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role Not Delete !" });
                }
                await _roleService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Role Is Delete !" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles([FromForm] RoleDto RoleData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Role Roles = new Role();
                    Roles.RoleName = RoleData.RoleName;
                    if (RoleData != null)
                    {
                        await _roleService.update(Roles);
                        return Ok(new Response { Status = "Success", Message = "Role Update Successfully !" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role Not Update!" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}
