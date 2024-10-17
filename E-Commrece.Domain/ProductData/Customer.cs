using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Product
{
    public class Customer : BaseEntityModel
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public int Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public ICollection<Orders> orders { get; set; }

        public ICollection<CustomerPayment> CustomerPayment { get; set; }
        public ICollection<Review> Review { get; set; }

    }
}
