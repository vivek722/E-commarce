using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Admin
{
    public interface ISupplierPageSettingService : IGenricservice<SupplierPageSetting>
    {
        Task<List<SupplierPageSetting>> SearchSupplierPage(string search);
    }
}
