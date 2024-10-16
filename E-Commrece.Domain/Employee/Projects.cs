using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Employee
{
    public class Projects : BaseEntityModel
    {
        [MaxLength(100)]
        public string ProjectName { get; set; }
        public DateTime StartDated { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EmployeeProject> EmployeeProject { get; set; }

    }
}
