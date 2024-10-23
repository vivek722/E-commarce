using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Addresse : BaseEntityModel
    {
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        public int Userid { get; set; }
        [ForeignKey("Userid")]
        public Users User { get; set; }

    }
}
