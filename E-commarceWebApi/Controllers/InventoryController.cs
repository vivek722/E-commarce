using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Payment;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly InventoryIService _inventoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IProductService  _productService;
        private readonly IMapper _mapper;
        public InventoryController(IMapper mapper, InventoryIService inventoryService, IWarehouseService warehouseService, IProductService productService)
        {
            _inventoryService = inventoryService;
            _warehouseService = warehouseService;
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("GetAllInventory")]
        public async Task<IActionResult> GetAllInventory( string? SerchString)
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
        public async Task<IActionResult> AddInventory(InventoryDto inventoryDto)
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
                    inventory.ProductId = inventoryDto.product_id;
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
              await _inventoryService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromForm] InventoryDto inventoryDto)
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
    }
}