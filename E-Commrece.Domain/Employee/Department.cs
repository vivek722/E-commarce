using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Employee
{
    public class Department : BaseEntityModel
    {
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
