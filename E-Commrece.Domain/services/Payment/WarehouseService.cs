using E_commerce.Ef.Core.Payment;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Payment
{
    public class WarehouseService : GenericService<Warehouse>,IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository) : base(warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public Task<List<Warehouse>> SearchWarehouse(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
