using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain;
using E_Commrece.Domain.services.Base;
using E_Commrece.Domain.services.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext _applicationDbContext) : base(_applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<List<Users>> SearchUsers(string SearchString)
        {
            return await applicationDbContext.Users.AsNoTracking().Where(x => x.UserName == SearchString || x.Email == SearchString).Include(x => x.Role).ToListAsync();
        }
        public override async Task<List<Users>> GetAll()
        {
            return await applicationDbContext.Users.AsNoTracking().Include(x => x.Addresse).ToListAsync();
        }
        public override async Task<Users> GetById(int id)
        {
            return await applicationDbContext.Users.AsNoTracking().Where(x => x.id == id).Include(x => x.Addresse).FirstOrDefaultAsync();
        }
    }
}
