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
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeProjectService _employeeProjectService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IProjectService projectService, IEmployeeProjectService employeeProjectService, IMapper mapper)
        {
            _employeeService = employeeService;
            _projectService = projectService;
            _employeeProjectService = employeeProjectService;
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
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeDto EmpData)
        {
            if (EmpData == null)
            {
                return BadRequest();
            }
            var projects = _mapper.Map<List<Projects>>(EmpData.projects);
            if (projects != null)
            {
                foreach (var project in projects)
                {
                    await _projectService.Add(project);
                }
            }
            var emp = _mapper.Map<Employees>(EmpData);
            if (ModelState.IsValid)
            {
                await _employeeService.Add(emp);
                return Ok("Employee Data Add Successfully");
            }
            EmployeeProject employeeProject = new EmployeeProject();

            employeeProject.EmployeeId = emp.id;
            foreach (var project in projects)
            {
                employeeProject.ProjectId = project.id;
            }
            if (employeeProject != null)
            {
                await _employeeProjectService.Add(employeeProject);
            }
            return Ok(emp);
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmplyee([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Not in 0 or Lessthen 0");
            }
            await _employeeService.Delete(id);
            return Ok("Em Deleted Successfully");
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeDto EmpData)
        {
            var emp = _mapper.Map<Employees>(EmpData);
            if (ModelState.IsValid)
            {
                    await _employeeService.update(emp);
                    return Ok("Update Updated Successfully");

            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
