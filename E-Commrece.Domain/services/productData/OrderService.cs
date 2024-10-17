﻿using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.productData
{
    public class OrderService : GenericService<Orders>, IOrderService
    {
        public OrderService(IGenricRepository<Orders> genricRepository) : base(genricRepository)
        {

        }
        public Task<List<Orders>> SearchOrder(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
