using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Payment
{
    public interface InventoryIRepository : IGenricRepository<Inventory>
    {
        Task<List<Inventory>> SearchInventory(string SearchString);
    }
}
