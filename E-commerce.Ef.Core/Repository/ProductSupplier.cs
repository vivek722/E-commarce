using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.ResponseModel;
using E_Commrece.Domain.services.productData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class ProductSupplier : GenericRepository<Products>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductSupplier(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<List<Products>> SearchProduct(string SearchString)
        {
            return _context.Products.AsNoTracking().Where(x => x.ProductName == SearchString).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllProducts(string SearchString)
        {
            return await _context.ProductDto.FromSqlInterpolated($"EXEC getallproducts").ToListAsync();
        }

       
        
    }
}
