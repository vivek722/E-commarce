using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.services.Base;
using E_Commrece.Domain.services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext applicationDb;
        public DepartmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            applicationDb= applicationDbContext;
        }
        public Task<List<Employees>> SearchEmployee(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}

