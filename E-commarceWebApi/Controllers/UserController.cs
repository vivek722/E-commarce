using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _userService.GetAllUsers();
                return Ok(roles);
            }
            var Searchroles = await _userService.SearchUsers(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDto UserData)
        {
            if (ModelState.IsValid)
            {
                var User = _mapper.Map<Users>(UserData);
                {
                   await _userService.AddUser(User);
                    return Ok(User);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _userService.DeleteUser(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDto UserData)
        {
            if (ModelState.IsValid)
            {
                {
                //    await _userService.updateUser(RoleData.id, Roles);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
