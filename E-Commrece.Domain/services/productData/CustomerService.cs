using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.productData
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        public CustomerService(IGenricRepository<Customer> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<Customer>> SearchCustomer(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
