using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        [HttpGet("GetAllEDepartments")]
        public async Task<IActionResult> GetAllEDepartments([FromForm] string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _departmentService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _departmentService.SearchEmployee(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromForm] DepartmentDto Department)
        {
            if (Department == null)
            {
                return BadRequest();
            }
            var emp = _mapper.Map<Department>(Department);
            if (ModelState.IsValid)
            {
                await _departmentService.Add(emp);
                return Ok("Department Data Updated Successfully");
            }

            return Ok(emp);
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _departmentService.Delete(id);
            return Ok("Department Data Deleted Successfully");
        }
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromForm] DepartmentDto Department)
        {
            var DepartmentData = _mapper.Map<Department>(Department);
            if (ModelState.IsValid)
            {
                await _departmentService.update(DepartmentData);
                return Ok("Department Data Updated Successfully");

            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
