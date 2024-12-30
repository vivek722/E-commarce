using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class CustomerPageSettingRepository : GenericRepository<CustomerPageSetting>, ICustomerPageSettingRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerPageSettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<CustomerPageSetting>> SearchCustomerPage(string search)
        {
            return await _context.CustomerPageSetting.AsNoTracking().Where(x=>x.PageName == search).ToListAsync();
        }
    }
}
