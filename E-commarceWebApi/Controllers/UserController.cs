using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<Users> _passwordHasher;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<Users>();
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser([FromForm] string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _userService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _userService.SearchUsers(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromForm] UserDto UserData)
        {
            if (ModelState.IsValid)
            {
                var User = _mapper.Map<Users>(UserData);
                {
                     User.PasswordHash  = _passwordHasher.HashPassword(User, UserData.PasswordHash);
                    await _userService.Add(User);
                    return Ok(User);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _userService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDto UserData)
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
