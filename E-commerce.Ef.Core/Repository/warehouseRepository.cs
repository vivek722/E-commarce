using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.services.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class warehouseRepository : GenericRepository<Warehouse>,IWarehouseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext1;
        public warehouseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext1 = applicationDbContext;
        }

        public Task<List<Warehouse>> SearchInventory(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
