using E_commerce.Ef.Core.User;
using E_Commrece.Domain;
using E_Commrece.Domain.services.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;
        }
        public async Task<Users> AddUser(Users User)
        {
            await applicationDbContext.Users.AddAsync(User);
            await applicationDbContext.SaveChangesAsync();
            return User;
        }

        public async Task<Users> DeleteUser(int id)
        {
            var deleteUser = await this.GetUserById(id);
            applicationDbContext.Users.Remove(deleteUser);
            await applicationDbContext.SaveChangesAsync();
            return deleteUser;

        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await applicationDbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await applicationDbContext.Users.AsNoTracking().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Users>> SearchUsers(string SearchString)
        {
            return await applicationDbContext.Users.AsNoTracking().Where(x => x.UserName == SearchString).ToListAsync();
        }

        public async Task<Users> updateUser(int id, Users User)
        {
            var OldUser = await this.GetUserById(id);
            User.id = OldUser.id;
            applicationDbContext.Users.Update(User);
            applicationDbContext.SaveChanges();
            return User;
        }
    }
}
