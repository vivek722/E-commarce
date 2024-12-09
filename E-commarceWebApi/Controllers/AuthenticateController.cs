﻿using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISupplierService _supplierService;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IUserService userService, IConfiguration configuration, ISupplierService supplierService)
        {
            _userService = userService;
            _configuration = configuration;
            _supplierService = supplierService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                var users = await _userService.SearchUsers(login.UserName);
                var user =  users.FirstOrDefault();
                if (user != null && VerifyPassword(user.PasswordHash, login.Password))
                {
                    return Ok(new { token = GenerateJwtToken(user.UserName, user.id, user.Role.RoleName) });
                }

                var suppliers = await _supplierService.SearchSupplier(login.UserName);
                var supplier = suppliers.FirstOrDefault();
                if (supplier != null && VerifyPassword(supplier.Password, login.Password))
                {
                    return Ok(new { token = GenerateJwtToken(supplier.UserName, supplier.id, supplier.Role.RoleName) });
                }

                return Unauthorized("Invalid username or password.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        private bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.VerifyHashedPassword(null, hashedPassword, inputPassword) == PasswordVerificationResult.Success;
        }

        private string GenerateJwtToken(string userName, int id, string roleName)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Name", userName),
                new Claim("Id", id.ToString()),
                new Claim("Role", roleName)
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //[HttpGet("GetRoledata/{email}")]
        [HttpGet]
        [Route("GetRoledata/{email}")]
        public async Task<IActionResult> GetRoledata(string email)
        {
            var roleData = await _userService.GetRoledata(email);
            return Ok(roleData.Role.RoleName);
        }
        }
}
