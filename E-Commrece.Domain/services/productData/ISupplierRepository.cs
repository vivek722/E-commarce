﻿using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.productData
{
    public interface ISupplierRepository : IGenricRepository<Supplier>
    {
        Task<List<Supplier>> SearchSupplier(string SearchString);
    }
}
