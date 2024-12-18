﻿using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Payment
{
    public class InventoryService : GenericService<Inventory>, InventoryIService
    {
        private readonly InventoryIRepository _inventoryRepository;

        public InventoryService(InventoryIRepository inventoryRepository) : base(inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public Task<List<Inventory>> SearchInventory(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
