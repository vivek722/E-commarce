using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Payment
{
    public interface IWarehouseService : IGenricservice<Warehouse>
    {
        Task<List<Warehouse>> SearchInventory(string SearchString);
    }
}
