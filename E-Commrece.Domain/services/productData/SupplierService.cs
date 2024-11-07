using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using E_Commrece.Domain.services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.productData
{
    public class SupplierService : GenericService<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) : base(supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public Task<List<Supplier>> SearchSupplier(string SearchString)
        {
            return _supplierRepository.SearchSupplier(SearchString);
        }
    }
}
