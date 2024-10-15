using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Employee;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpGet("GetAllEmployess")]
        public async Task<IActionResult> GetAllEmployess(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _employeeService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _employeeService.SearchEmployee(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto EmpData)
        {
            if (EmpData == null)
            {
                return BadRequest();
            }
            var emp = _mapper.Map<Employees>(EmpData);
            if (ModelState.IsValid)
            {
                await _employeeService.Add(emp);
                return Ok("Role Updated Successfully");
            }

            return Ok(emp);
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteCountrie(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _employeeService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateCountrie(EmployeeDto EmpData)
        {
            var emp = _mapper.Map<Employees>(EmpData);
            if (ModelState.IsValid)
            {
                    await _employeeService.update(emp);
                    return Ok("Role Updated Successfully");

            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
