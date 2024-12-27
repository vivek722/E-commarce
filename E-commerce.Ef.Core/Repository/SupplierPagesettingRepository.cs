using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
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
    public class SupplierPagesettingRepository : GenericRepository<SupplierPageSetting>, ISupplierPageSettingRepository
    {
        public SupplierPagesettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Task<List<SupplierPageSetting>> SearchSupplierPage(string search)
        {
            throw new NotImplementedException();
        }
    }
}
