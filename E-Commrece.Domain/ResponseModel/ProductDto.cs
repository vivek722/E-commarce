using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.ResponseModel
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductOrignalprice { get; set; }
        public decimal ProductActualprice { get; set; }
        public string ProductImag { get; set; }
    }
}
