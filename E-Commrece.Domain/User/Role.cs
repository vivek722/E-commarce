using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Role
    {
        public int id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Users> users { get; set; }
    }
}
