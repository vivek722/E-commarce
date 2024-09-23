using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public interface ICountrieRepository
    {
        Task<List<Countrie>> GetAllCountries();
        Task<Countrie> GetCountrieById(int id);
        Task<List<Countrie>> SearchCountries(string SearchString);
        Task<Countrie> AddCountrie(Countrie countrie);
        Task<Countrie> DeleteCountrie(int id);
        Task<Countrie> updateCountrie(int id, Countrie countrie);
    }
}
