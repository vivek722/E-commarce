using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class RoleService : GenericService<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<List<Role>> SearchRoles(string SearchString)
        {
            return _roleRepository.SearchRoles(SearchString);
        }
    }
}
