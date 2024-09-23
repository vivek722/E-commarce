using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Citie
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Countrie Country { get; set; }
    }
}
