using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Admin
{
    public class AdminService : GenericService<AdminModel>, IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository) : base(adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Task<List<AdminModel>> SearchAdmin(string search)
        {
            return _adminRepository.SearchAdmin(search);
        }
    }
}
