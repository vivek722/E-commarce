using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Employee
{
    public interface IProjectRepository : IGenricRepository<Projects>
    {
        Task<List<Projects>> SearchPoject(string SearchString);
    }
}
