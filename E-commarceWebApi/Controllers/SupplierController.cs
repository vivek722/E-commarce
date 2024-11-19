using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using E_commerce.Ef.Core.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using E_Commrece.Domain.Email_SMS_Sender;
using E_commarceWebApi.RequestModel.ResponseModel;
using System.Net.NetworkInformation;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;
        private readonly IMapper _mapper;

        private readonly IEmailSender _emailSender;

        private readonly PasswordHasher<Supplier> _passwordHasher;

        public SupplierController(SupplierService supplierService, IMapper mapper, IEmailSender emailSender)
        {
            _supplierService = supplierService;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<Supplier>();
            _emailSender = emailSender;

        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers(string? SerchString)
        {
            try
            {
                if (SerchString == null)
                {
                    var roles = await _supplierService.GetAll();
                    return Ok(roles);
                }
                var Searchroles = await _supplierService.SearchSupplier(SerchString);
                return Ok(Searchroles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SupplierDto supplierDto)
        {
            try
            {
                var SupplierUserName = await _supplierService.SearchSupplier(supplierDto.UserName);
                if (SupplierUserName.Count() >0)
                {
                    return Ok(new Response { Status = "Error", Message = "ThIs SupplierUserName Already Exists!" });
                }
                if (ModelState.IsValid)
                {
                    var Supplier = _mapper.Map<Supplier>(supplierDto);
                    if (Supplier != null)
                    {
                        Supplier.Password = _passwordHasher.HashPassword(Supplier, supplierDto.Password);
                        await _supplierService.Add(Supplier);
                        await _emailSender.SendEmailAsync(supplierDto.Email, "Thank You To Join Our ShopMart!", supplierDto.UserName);
                        return Ok(new Response { Status = "Success", Message = "Supplier Add SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Supplier Not Add" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromForm] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _supplierService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Supplier Delete SuccessFully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromForm] SupplierDto supplierDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supplier = _mapper.Map<Supplier>(supplierDto);
                    if (supplier != null)
                    {
                        await _supplierService.update(supplier);
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
