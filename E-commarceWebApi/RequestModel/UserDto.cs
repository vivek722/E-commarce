using E_commerce.Ef.Core.User;
using System.ComponentModel.DataAnnotations;

namespace E_commarceWebApi.RequestModel
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public AddressDto AddressDto { get; set; }
    }
}
