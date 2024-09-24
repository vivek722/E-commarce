    using E_commerce.Ef.Core.Payment;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace E_commerce.Ef.Core.Employee
    {
        public class Employees
        {
            public int id { get; set; }
            [MaxLength(100)]
            public string FirstName { get; set; }
            [MaxLength(100)]
            public string LastName { get; set; }
            public int DepartmentId { get; set; }
            [ForeignKey("DepartmentId")]
            public Department Department { get; set; }
            //[ForeignKey("EmployeeId")]
            public int? ManagerId { get; set; }

            public Employees Manager { get; set; }
            public ICollection<EmployeeProject> EmployeeProject { get; set; }
            public ICollection<Employees> Subordinates { get; set; }
        }
    }
