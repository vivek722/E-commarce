using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Users> AddUser(Users User)
        {
            return _userRepository.AddUser(User);
        }

        public Task<Users> DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);    
        }

        public Task<List<Users>> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<Users> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public Task<List<Users>> SearchUsers(string SearchString)
        {
            return _userRepository.SearchUsers(SearchString);
        }

        public Task<Users> updateUser(int id, Users User)
        {
            return _userRepository.updateUser(id,User);
        }
    }
}
