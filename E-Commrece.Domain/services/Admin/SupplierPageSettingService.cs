using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Admin
{
    public class SupplierPageSettingService : GenericService<SupplierPageSetting>, ISupplierPageSettingService
    {
        public SupplierPageSettingService(IGenricRepository<SupplierPageSetting> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<SupplierPageSetting>> SearchSupplierPage(string search)
        {
            throw new NotImplementedException();
        }
    }
}
