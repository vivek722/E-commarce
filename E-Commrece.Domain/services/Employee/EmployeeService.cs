using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public class EmployeeService : GenericService<Employees>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<List<Employees>> SearchEmployee(string SearchString)
        {
            return _employeeRepository.SearchEmployee(SearchString);
        }
    }
}
