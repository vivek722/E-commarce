using E_commerce.Ef.Core.Product;
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
    public class WishListRepository : GenericRepository<Wishlist>, IWishlistRepository
    {
        private readonly ApplicationDbContext _context;
        public WishListRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<Wishlist> isProductInWishlist(int productId, int UserId)
        {
            return _context.Wishlist.AsNoTracking().Where(x => x.ProductId == productId && x.UserId == UserId).FirstOrDefaultAsync();
        }

        public Task<List<Wishlist>> SearcWishlist(string SearchString)
        {
            throw new NotImplementedException();
        }
        public override Task<List<Wishlist>> GetAll()
        {
            return _context.Wishlist.AsNoTracking().Include(x => x.Product).ThenInclude(x=>x.ProductImage).ToListAsync();
        }
    }
}
