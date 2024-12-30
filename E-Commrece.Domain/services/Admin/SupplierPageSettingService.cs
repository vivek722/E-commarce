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
        private readonly ISupplierPageSettingRepository _supplierPageSettingRepository;
        public SupplierPageSettingService(ISupplierPageSettingRepository supplierPageSettingRepository) : base(supplierPageSettingRepository)
        {
            _supplierPageSettingRepository = supplierPageSettingRepository;
        }

        public Task<List<SupplierPageSetting>> SearchSupplierPage(string search)
        {
            return _supplierPageSettingRepository.SearchSupplierPage(search);
        }
    }
}
