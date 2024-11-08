using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.Email_SMS_Sender;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly PasswordHasher<Users> _passwordHasher;

        public UserController(IUserService userService, IMapper mapper, IEmailSender emailSender)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<Users>();
            _emailSender = emailSender;
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
        public async Task<IActionResult> AddUser(UserDto UserData)
        {
            if (ModelState.IsValid)
            {

                var User = _mapper.Map<Users>(UserData);
                {
                    if (User != null)
                    {
                        if (UserData.AddressDto != null)
                        {
                            User.Addresse = new Addresse // A
                            {
                                Street = UserData.AddressDto.Street,
                                City = UserData.AddressDto.City,
                                State = UserData.AddressDto.State,
                                ZipCode = UserData.AddressDto.ZipCode
                            };
                            User.PasswordHash = _passwordHasher.HashPassword(User, UserData.PasswordHash);
                            await _userService.Add(User);
                            await _emailSender.SendEmailAsync(UserData.Email, "Welcome to Our ShopMart!",UserData.UserName);
                        }
                    }
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
