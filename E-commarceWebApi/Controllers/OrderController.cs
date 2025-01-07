using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.productData;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(string? SerchString)
        {
            try
            {
                if (SerchString == null)
                {
                    var AllOrders = await _orderService.GetAll();
                    return Ok(new DataResponseList() { Data = AllOrders, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchOrders = await _orderService.SearchOrder(SerchString);
                return Ok(new DataResponseList() { Data = SearchOrders, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var OrderDataByid = await _orderService.GetById(id);
                return Ok(new DataResponseList() { Data = OrderDataByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromForm] OrderDto orderDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderData = _mapper.Map<Orders>(orderDto);  
                    if (orderData != null)
                    {
                         await _orderService.Add(orderData);
                        return Ok(new Response { Status = "Success", Message = "Your Order Place SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Your Order Not Place" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _orderService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Your Order Remove SuccessFully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromForm] OrderDto OrderDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderData = _mapper.Map<Orders>(OrderDto);
                    if (orderData != null)
                    {
                        await _orderService.update(orderData);
                        return Ok(new Response { Status = "Success", Message = "Your Order Updated SuccessFully" });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Order Not Updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}
