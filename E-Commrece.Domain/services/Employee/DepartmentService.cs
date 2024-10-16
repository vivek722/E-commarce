using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _repositories;
        public DepartmentService(IDepartmentRepository repositories) : base(repositories)
        {
            _repositories = repositories;
        }

        public Task<List<Employees>> SearchEmployee(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
