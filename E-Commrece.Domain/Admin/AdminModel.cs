using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commrece.Domain.BaseClass;

namespace E_Commrece.Domain.Admin
{
    public class AdminModel : BaseEntityModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
