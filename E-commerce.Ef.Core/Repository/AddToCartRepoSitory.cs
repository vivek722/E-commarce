using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.ProductData;
using E_Commrece.Domain.services.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class AddToCartRepoSitory : GenericRepository<AddToCart>, IAddToCartRepository
    {
        private readonly ApplicationDbContext _context;
        public AddToCartRepoSitory(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<AddToCart> isProductInCart(int productId, int UserId)
        {
            return _context.AddToCart.AsNoTracking().Where(x => x.ProductId == productId && x.UserId == UserId).FirstOrDefaultAsync();
        }

        public Task<List<AddToCart>> SearcAddToCart(string SearchString)
        {
            throw new NotImplementedException();
        }
        public override Task<List<AddToCart>> GetAll()
        {
            return _context.AddToCart.AsNoTracking().Include(x => x.Product).ThenInclude(x => x.ProductImage).ToListAsync();
        }
    }
}
