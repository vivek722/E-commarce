using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface ICountrieService : IGenricservice<Countrie>
    {
        Task<List<Countrie>> SearchCountries(string SearchString);
    }
}
