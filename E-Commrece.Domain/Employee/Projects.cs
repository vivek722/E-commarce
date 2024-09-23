using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Employee
{
    public class Projects
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string ProjectName { get; set; }
        public DateTime StartDated { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EmployeeProject> EmployeeProject { get; set; }

    }
}
