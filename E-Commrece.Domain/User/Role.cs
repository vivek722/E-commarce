using E_commerce.Ef.Core.Product;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Role : BaseEntityModel
    {
        public string RoleName { get; set; }
        public ICollection<Users> users { get; set; }
        public ICollection<Supplier> Supplier { get; set; }

        public ICollection<AdminModel> AdminModel { get; set; }
    }
}
