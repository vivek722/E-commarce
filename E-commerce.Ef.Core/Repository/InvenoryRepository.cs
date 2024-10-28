﻿using E_commerce.Ef.Core.Product;
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
    public class InvenoryRepository : GenericRepository<Inventory>, InventoryIRepository
    {
        private readonly ApplicationDbContext _applicationDbContext1;
        public InvenoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext1 = applicationDbContext;
        }

        public Task<List<Inventory>> SearchInventory(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}