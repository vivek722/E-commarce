using E_commerce.Ef.Core.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public interface IEmployeeService
    {
        Task<List<Employees>> GetAllEmployee();
        Task<Employees> GetEmployeeeById(int id);
        Task<List<Employees>> SearchEmployee(string SearchString);
        Task<Employees> AddEmployee(Employees EmployeeData);
        Task<Employees> DeleteEmployee(int id);
        Task<Employees> updateEmployee(int id, Employees EmployeeData);
    }
}
