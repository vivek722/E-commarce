using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<List<Role>> SearchRoles(string SearchString);
        Task<Role> AddRole(Role role);
        Task<Role> DeleteRole(int id);
        Task<Role> updateRole(int id,Role role);
    }
}
