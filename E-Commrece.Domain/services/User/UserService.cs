using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class UserService : GenericService<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<Users>> SearchUsers(string SearchString)
        {
            return _userRepository.SearchUsers(SearchString);
        }
    }
}
