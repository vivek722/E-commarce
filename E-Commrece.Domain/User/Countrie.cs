using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Countrie : BaseEntityModel
    {
        [MaxLength(100)]
        public string CountryName { get; set; }
        public ICollection<Citie> Cities { get; set; }
    }
}
