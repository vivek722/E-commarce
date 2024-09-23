using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Employee
{
    public class EmployeeProject
    {
        public int id { get; set; }
        [ForeignKey("EmployeeId")]

        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Projects Projects { get; set; }



    }
}
