using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
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
    public class SupplierPagesettingRepository : GenericRepository<SupplierPageSetting>, ISupplierPageSettingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SupplierPagesettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<SupplierPageSetting>> SearchSupplierPage(string search)
        {
           return await _applicationDbContext.SupplierPageSetting.AsNoTracking().Where(x=>x.PageName == search).ToListAsync();
        }
    }
}
