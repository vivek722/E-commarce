using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public class ProjectService : GenericService<Projects>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) : base(projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Task<List<Projects>> SearchProject(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
