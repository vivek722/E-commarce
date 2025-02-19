﻿using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.services.productData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<List<Supplier>> SearchSupplier(string SearchString)
        {
            return _context.Suppliers.AsNoTracking().Where(x => x.UserName == SearchString || x.CompanyName == SearchString).Include(x => x.Role).ToListAsync();
        }
    }
}
