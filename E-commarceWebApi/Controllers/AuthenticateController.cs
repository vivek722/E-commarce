using E_commarceWebApi.RequestModel;
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
            var users = await _userService.SearchUsers(login.UserName);
            var User = users.FirstOrDefault();

            if (User == null)
            {
                var suppliers = await _supplierService.SearchSupplier(login.UserName);
                var supplier = suppliers.FirstOrDefault();

                if (supplier != null)
                {
                    var passwordHasher = new PasswordHasher<Supplier>();
                    var verificationResult = passwordHasher.VerifyHashedPassword(supplier, supplier.Password, login.Password);

                    if (verificationResult == PasswordVerificationResult.Failed)
                    {
                        return Unauthorized("Invalid username or password.");
                    }

                    var authClaims = new List<Claim>
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name,supplier.UserName),
                    new Claim("Id",supplier.id.ToString()),
                    new Claim("Role",supplier.Role.RoleName),
                    };
                    var token = GetToken(authClaims);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                    });
                }
            }
                if (User != null)
                {
                    var passwordHasher = new PasswordHasher<Users>();
                    var verificationResult = passwordHasher.VerifyHashedPassword(User, User.PasswordHash, login.Password);

                    if (verificationResult == PasswordVerificationResult.Failed)
                    {
                        return Unauthorized("Invalid username or password.");
                    }
                    var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name,User.UserName),
                    new Claim("Id",User.id.ToString()),
                    new Claim("Role",User.Role.RoleName),
                };
                    var token = GetToken(authClaims);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                    });
                }
            
            return BadRequest("Please Provide Valid User");
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
