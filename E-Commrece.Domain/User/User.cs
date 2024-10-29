using E_Commrece.Domain.BaseClass;
using E_Commrece.Domain.ProductData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Users : BaseEntityModel
    {
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public Addresse Addresse { get; set; }
        public AddToCart AddToCart { get; set; }
        public Wishlist Wishlist { get; set; }


    }
}
