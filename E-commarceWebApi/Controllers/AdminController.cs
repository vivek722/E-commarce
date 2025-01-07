using AutoMapper;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.productData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_Commrece.Domain.Email_SMS_Sender;
using E_Commrece.Domain.services.Admin;
using E_Commrece.Domain.Admin;

namespace E_commarceWebApi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        private readonly IEmailSender _emailSender;

        private readonly PasswordHasher<AdminModel> _passwordHasher;

        public AdminController(IAdminService adminService, IMapper mapper, IEmailSender emailSender)
        {
            _adminService = adminService;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<AdminModel>();
            _emailSender = emailSender;

        }

        [HttpGet("GetAllAdmin")]
        public async Task<IActionResult> GetAllAdmin(string? SerchString)
        {
            try
            {
                if (SerchString == null)
                {
                    var AllAdmins = await _adminService.GetAll();
                    return Ok(new DataResponseList() { Data = AllAdmins, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchAdmin = await _adminService.SearchAdmin(SerchString);
                return Ok(new DataResponseList() { Data = SearchAdmin, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetAdminById/{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            try
            {
                var AdminDataByid = await _adminService.GetById(id);
                return Ok(new DataResponseList() { Data = AdminDataByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromForm] AdminDto adminDto)
        {
            try
            {
                var AdminUserName = await _adminService.SearchAdmin(adminDto.UserName);
                if (AdminUserName.Count() > 0)
                {
                    return Ok(new Response { Status = "Error", Message = "ThIs SupplierUserName Already Exists!" });
                }
                if (ModelState.IsValid)
                {
                    var Admin = _mapper.Map<AdminModel>(adminDto);
                    if (Admin != null)
                    {
                        Admin.Password = _passwordHasher.HashPassword(Admin, adminDto.Password);
                        await _adminService.Add(Admin);
                        //await _emailSender.SendEmailAsync(adminDto.Email, "Thank You To Join Our ShopMart!", adminDto.UserName);
                        return Ok(new Response { Status = "Success", Message = "Admin Add SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Supplier Not Add" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _adminService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Supplier Delete SuccessFully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin([FromForm] AdminDto adminDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var adminModel = _mapper.Map<AdminModel>(adminDto);
                    if (adminModel != null)
                    {
                        await _adminService.update(adminModel);
                        return Ok(new Response { Status = "Success", Message = "Supplier Update SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Supplier Not Updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}
