using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<List<Users>> SearchUsers(string SearchString);
        Task<Users> AddUser(Users User);
        Task<Users> DeleteUser(int id);
        Task<Users> updateUser(int id, Users User);
    }
}
