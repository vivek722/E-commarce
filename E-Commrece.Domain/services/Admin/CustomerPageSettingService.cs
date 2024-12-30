using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Admin
{
    public class CustomerPageSettingService : GenericService<CustomerPageSetting>, ICustomerPageSettingService
    {
        private readonly ICustomerPageSettingRepository _repository;
        public CustomerPageSettingService(ICustomerPageSettingRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public Task<List<CustomerPageSetting>> SearchCustomerPage(string search)
        {
          return _repository.SearchCustomerPage(search);
        }
    }
}
