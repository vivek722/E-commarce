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
    public class EmployeeProjectRepository : GenericRepository<EmployeeProject>, IEmployeeProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeProjectRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<List<Projects>> SearchPoject(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
