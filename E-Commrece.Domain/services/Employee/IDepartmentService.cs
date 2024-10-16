using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public interface IDepartmentService : IGenricservice<Department>
    { 
        Task<List<Employees>> SearchEmployee(string SearchString);
    }
}
