using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Employee
{
    public class Department
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
