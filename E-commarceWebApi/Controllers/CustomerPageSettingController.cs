using AutoMapper;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commarceWebApi.RequestModel;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    public class CustomerPageSettingController : Controller
    {
        private readonly ICustomerPageSettingService _customerPageSettingService;
        private readonly IMapper _mapper;

        public CustomerPageSettingController(ICustomerPageSettingService customerPageSettingService, IMapper mapper)
        {
            _customerPageSettingService = customerPageSettingService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCustomerPage")]
        public async Task<IActionResult> GetAllCustomerPage(string? SerchString)
        {
            try
            {
                if (SerchString == null)
                {
                    var AllAdmins = await _customerPageSettingService.GetAll();
                    return Ok(new DataResponseList() { Data = AllAdmins, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchAdmin = await _customerPageSettingService.SearchCustomerPage(SerchString);
                return Ok(new DataResponseList() { Data = SearchAdmin, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetCustomerPageById/{id}")]
        public async Task<IActionResult> GetCustomerPageById(int id)
        {
            try
            {
                var AdminDataByid = await _customerPageSettingService.GetById(id);
                return Ok(new DataResponseList() { Data = AdminDataByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("CustomerPageAdmin")]
        public async Task<IActionResult> CustomerPageAdmin(CustomerPageSettingDto CustomerPageSettingDto)
        {
            try
            {
                var CustomerPageName = await _customerPageSettingService.SearchCustomerPage(CustomerPageSettingDto.PageName);
                if (CustomerPageName.Count() > 0)
                {
                    return Ok(new Response { Status = "Error", Message = "ThIs SupplierUserName Already Exists!" });
                }
                if (ModelState.IsValid)
                {
                    var CustomerPageSetting = _mapper.Map<CustomerPageSetting>(CustomerPageSettingDto);
                    if (CustomerPageSetting != null)
                    {
                        await _customerPageSettingService.Add(CustomerPageSetting);
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
        [HttpDelete("DeleteCustomerPage")]
        public async Task<IActionResult> DeleteCustomerPage(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _customerPageSettingService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Supplier Delete SuccessFully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut("UpdateCustomerPage")]
        public async Task<IActionResult> UpdateCustomerPage(CustomerPageSettingDto CustomerPageSettingDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CustomerPageSetting = _mapper.Map<CustomerPageSetting>(CustomerPageSettingDto);
                    if (CustomerPageSetting != null)
                    {
                        await _customerPageSettingService.update(CustomerPageSetting);
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
