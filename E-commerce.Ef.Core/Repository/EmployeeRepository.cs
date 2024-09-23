using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain;
using E_Commrece.Domain.services.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Employees> AddEmployee(Employees EmployeeData)
        {
            await _applicationDbContext.Employees.AddAsync(EmployeeData);
            await _applicationDbContext.SaveChangesAsync();
            return EmployeeData;
        }

        public async Task<Employees> DeleteEmployee(int id)
        {
            var DeleteEmployee = await this.GetEmployeeeById(id);
            _applicationDbContext.Employees.Remove(DeleteEmployee);
            _applicationDbContext.SaveChanges();
            return DeleteEmployee;

        }

        public async Task<List<Employees>> GetAllEmployee()
        {
            return await _applicationDbContext.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<Employees> GetEmployeeeById(int id)
        {
            return await _applicationDbContext.Employees.AsNoTracking().Where(x=>x.id==id).FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> SearchEmployee(string SearchString)
        {
            return await _applicationDbContext.Employees.AsNoTracking().Where(x=>x.FirstName==SearchString || x.LastName == SearchString ).ToListAsync();
        }

        public async Task<Employees> updateEmployee(int id, Employees EmployeeData)
        {
            var OldEmployee = await this.GetEmployeeeById(id);
            EmployeeData.id = OldEmployee.id;
            _applicationDbContext.Employees.Update(EmployeeData);
            _applicationDbContext.SaveChanges();
            return EmployeeData;
        }
    }
}
