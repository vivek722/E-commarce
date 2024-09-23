﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.User
{
    public class Countrie
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string CountryName { get; set; }
        public ICollection<Citie> Cities { get; set; }
    }
}
