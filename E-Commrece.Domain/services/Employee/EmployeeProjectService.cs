using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public class EmployeeProjectService : GenericService<EmployeeProject>, IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository _repository;
        public EmployeeProjectService(IEmployeeProjectRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<List<Projects>> SearchPoject(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
