using System.ComponentModel.DataAnnotations;

namespace E_commarceWebApi.RequestModel
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
