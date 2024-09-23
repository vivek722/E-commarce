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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;
        public RoleRepository(ApplicationDbContext applicationDb)
        {
            dbContext = applicationDb;
        }
        public async Task<Role> AddRole(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteRole(int id)
        {
            var Role  = await this.GetRoleById(id);
            dbContext.Roles.Remove(Role);
            dbContext.SaveChanges();
            return Role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await dbContext.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await dbContext.Roles.AsNoTracking().Where(x=>x.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Role>> SearchRoles(string SearchString)
        {
            return await dbContext.Roles.AsNoTracking().Where(x => x.RoleName == SearchString).ToListAsync();
        }

        public async Task<Role> updateRole(int id, Role role)
        {
            var OldRole = await this.GetRoleById(id);
            role.id = OldRole.id;
            dbContext.Roles.Update(role);
            dbContext.SaveChanges();
            return role;
        }
    }
}
