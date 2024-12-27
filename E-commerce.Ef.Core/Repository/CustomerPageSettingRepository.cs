using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class CustomerPageSettingRepository : GenericRepository<CustomerPageSetting>, ICustomerPageSettingRepository
    {
        public CustomerPageSettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Task<List<CustomerPageSetting>> SearchCustomerPage(string search)
        {
            throw new NotImplementedException();
        }
    }
}
