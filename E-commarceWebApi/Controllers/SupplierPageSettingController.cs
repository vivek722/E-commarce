using AutoMapper;
using E_commarceWebApi.RequestModel.ResponseModel;
using E_commarceWebApi.RequestModel;
using E_Commrece.Domain.services.Admin;
using Microsoft.AspNetCore.Mvc;
using E_Commrece.Domain.Admin;
using Newtonsoft.Json.Schema;
using Microsoft.IdentityModel.Tokens;

namespace E_commarceWebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class SupplierPageSettingController : Controller
    {
        private readonly ISupplierPageSettingService _supplierPageSettingService;
        private readonly IMapper _mapper;

        public SupplierPageSettingController(ISupplierPageSettingService supplierPageSettingService, IMapper mapper)
        {
            _mapper = mapper;
            _supplierPageSettingService = supplierPageSettingService;
        }
        [HttpGet("GetAllSupplierPage")]
        public async Task<IActionResult> GetAllSupplierPage(string? SerchString)
            {
            try
            {
                if (SerchString.IsNullOrEmpty() || SerchString ==  "undefined")
                {
                    var AllAdmins = await _supplierPageSettingService.GetAll();
                    return Ok(new DataResponseList() { Data = AllAdmins, Status = StatusCodes.Status200OK, Message = "ok" });
                }
                var SearchAdmin = await _supplierPageSettingService.SearchSupplierPage(SerchString);
                return Ok(new DataResponseList() { Data = SearchAdmin, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet("GetSupplierPageById/{id}")]
        public async Task<IActionResult> GetSupplierPageById(int id)
        {
            try
            {
                var AdminDataByid = await _supplierPageSettingService.GetById(id);
                return Ok(new DataResponseList() { Data = AdminDataByid, Status = StatusCodes.Status200OK, Message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost("SupplierPageAdd")]
        public async Task<IActionResult> SupplierPageAdd(SupplierPageSettingDto SupplierPageSettingDto)
        {
            try
            {
                var SupplierPageName = await _supplierPageSettingService.SearchSupplierPage(SupplierPageSettingDto.PageName);
                if (SupplierPageName.Count() > 0)
                {
                    return Ok(new Response { Status = "Error", Message = "ThIs SupplierUserName Already Exists!" });
                }
                if (ModelState.IsValid)
                {
                    var SupplierPageSetting = _mapper.Map<SupplierPageSetting>(SupplierPageSettingDto);
                    if (SupplierPageSetting != null)
                    {
                        await _supplierPageSettingService.Add(SupplierPageSetting);
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
        [HttpDelete("DeleteSupplierPage/{id}")]
        public async Task<IActionResult> DeleteSupplierPage(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id Not in 0 or Lessthen 0" });
                }
                await _supplierPageSettingService.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Supplier Delete SuccessFully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut("UpdateSupplierPage")]
        public async Task<IActionResult> UpdateSupplierPage(SupplierPageSettingDto SupplierPageSettingDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CustomerPageSetting = _mapper.Map<SupplierPageSetting>(SupplierPageSettingDto);
                    if (CustomerPageSetting != null)
                    {
                        await _supplierPageSettingService.update(CustomerPageSetting);
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
