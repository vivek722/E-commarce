using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class ProjectRepository : GenericRepository<Projects>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<List<Projects>> SearchPoject(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
