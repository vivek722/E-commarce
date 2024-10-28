using E_commerce.Ef.Core.Payment;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Payment
{
    public  class warehouseService : GenericService<Warehouse>,IWarehouseService
    {
        public warehouseService(IGenricRepository<Warehouse> genricRepository) : base(genricRepository)
        {
        }

        public Task<List<Warehouse>> SearchInventory(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
