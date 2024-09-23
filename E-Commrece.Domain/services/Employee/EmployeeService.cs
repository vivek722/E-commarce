using E_commerce.Ef.Core.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;   
        }
        public Task<Employees> AddEmployee(Employees EmployeeData)
        {
            return _employeeRepository.AddEmployee(EmployeeData);
        }

        public Task<Employees> DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public Task<List<Employees>> GetAllEmployee()
        {
            return _employeeRepository.GetAllEmployee();
        }

        public Task<Employees> GetEmployeeeById(int id)
        {
            return _employeeRepository.GetEmployeeeById(id);
        }

        public Task<List<Employees>> SearchEmployee(string SearchString)
        {
            return _employeeRepository.SearchEmployee(SearchString);
        }

        public Task<Employees> updateEmployee(int id, Employees EmployeeData)
        {
            return _employeeRepository.updateEmployee(id, EmployeeData);
        }
    }
}
