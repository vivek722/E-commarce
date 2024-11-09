using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using E_commerce.Ef.Core.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<Supplier> _passwordHasher;

        public SupplierController(SupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<Supplier>();
        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers(string? SerchString)
            {
            if (SerchString == null)
            {
                var roles = await _supplierService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _supplierService.SearchSupplier(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                var Supplier = _mapper.Map<Supplier>(supplierDto);
                if (Supplier != null)
                {
                    Supplier.Password = _passwordHasher.HashPassword(Supplier, supplierDto.Password);
                    await _supplierService.Add(Supplier);
                    await _emailSender.SendEmailAsync(supplierDto.Email, "Thank You To Join Our ShopMart!", supplierDto.user);
                    return Ok(Supplier);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _supplierService.Delete(id);
            return Ok("supplier Deleted Successfully");
        }
        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromForm] SupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                if (supplier != null)
                {
                    await _supplierService.update(supplier);
                    return Ok("supplier Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
