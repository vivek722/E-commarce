using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Task<Role> AddRole(Role role)
        {
            return _roleRepository.AddRole(role);
        }

        public Task<Role> DeleteRole(int id)
        {
          return _roleRepository.DeleteRole(id);
        }

        public Task<List<Role>> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Task<Role> GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);   
        }

        public Task<List<Role>> SearchRoles(string SearchString)
        {
            return _roleRepository.SearchRoles(SearchString);
        }

        public Task<Role> updateRole(int id, Role role)
        {
            return _roleRepository.updateRole(id, role);
        }
    }
}
