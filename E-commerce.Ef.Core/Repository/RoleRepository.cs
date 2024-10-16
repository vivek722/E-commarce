using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain;
using E_Commrece.Domain.services.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<List<Role>> SearchRoles(string SearchString)
        {
            return await dbContext.Roles.AsNoTracking().Where(x => x.RoleName == SearchString).ToListAsync();
        }
    }
}
