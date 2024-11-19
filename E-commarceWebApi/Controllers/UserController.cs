using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.Product;
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
            try
            {
                if (SerchString == null)
                {
                    var roles = await _userService.GetAll();
                    return Ok(roles);
                }
                var Searchroles = await _userService.SearchUsers(SerchString);
                return Ok(Searchroles);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDto UserData)
        {
            try
            {
                var UserName = await _userService.SearchUsers(UserData.UserName);
                if (UserName != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError ,new Response { Status = "Error", Message = "ThIs UserName Already Exists!" });
                }
                if (ModelState.IsValid)
                {
                    var User = _mapper.Map<Users>(UserData);
                    {
                        if (User != null)
                        {
                            if (UserData != null)
                            {
                                User.Addresse = new Addresse
                                {
                                    Street = UserData.Street,
                                    City = UserData.City,
                                    State = UserData.State,
                                    ZipCode = UserData.ZipCode
                                };
                                User.PasswordHash = _passwordHasher.HashPassword(User, UserData.PasswordHash);
                                await _userService.Add(User);
                                await _emailSender.SendEmailAsync(UserData.Email, "Welcome to Our ShopMart!", UserData.UserName);
                            }
                        }
                        return Ok(new Response { Status = "Success", Message = "User Add SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Not Add" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
          }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromForm] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _userService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "User Delete SuccessFully" });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDto UserData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var User = _mapper.Map<Users>(UserData);
                    if (User != null)
                    {
                        await _userService.update(User);
                        return Ok(new Response { Status = "Success", Message = "User Data Update SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Data Not Update" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
    }
