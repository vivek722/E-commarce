using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Payment;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        public InventoryController(ICountrieService countrieService, IMapper mapper,IInventoryService inventoryService, IWarehouseService warehouseService)
        {
            _inventoryService = inventoryService;
            _warehouseService = warehouseService;
            _mapper = mapper;
        }
        [HttpGet("GetInventory")]
        public async Task<IActionResult> GetInventory([FromForm] string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _inventoryService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _inventoryService.SearchInventory(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddInventory")]
        public async Task<IActionResult> AddInventory([FromForm] InventoryDto inventoryDto)
        {
            if (ModelState.IsValid)
            {
                var Warehouse = _mapper.Map<Warehouse>(inventoryDto);
                if (Warehouse != null)
                {
                    await _warehouseService.Add(Warehouse);
                }
                var inventory = _mapper.Map<Inventory>(inventoryDto);
                if (inventory != null)
                {
                    inventory.WarehouseId = Warehouse.id;
                    await _inventoryService.Add(inventory);
                    return Ok(inventory);
                }

            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteInventory")]
        public async Task<IActionResult> DeleteInventory([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is Not  0 or Lessthen 0");
            }
          //  await _countrieService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromForm] CountrieDto Countrie)
        {
            if (ModelState.IsValid)
            {
                Countrie countries = new Countrie();
                countries.CountryName = Countrie.CountryName;
                if (countries != null)
                {
                   // await _countrieService.update(countries);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
