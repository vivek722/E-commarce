using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class CountrieService : ICountrieService
    {
        private readonly ICountrieRepository _countrieRepository;

        public CountrieService(ICountrieRepository countrieRepository)
        {
            _countrieRepository = countrieRepository;
        }
        public Task<Countrie> AddCountrie(Countrie countrie)
        {
            return _countrieRepository.AddCountrie(countrie);
        }

        public Task<Countrie> DeleteCountrie(int id)
        {
            return _countrieRepository.DeleteCountrie(id);
        }

        public Task<List<Countrie>> GetAllCountries()
        {
           return _countrieRepository.GetAllCountries();
        }

        public Task<Countrie> GetCountrieById(int id)
        {
            return _countrieRepository.GetCountrieById(id);
        }

        public Task<List<Countrie>> SearchCountries(string SearchString)
        {
            return _countrieRepository.SearchCountries(SearchString);
        }

        public Task<Countrie> updateCountrie(int id, Countrie countrie)
        {
            return _countrieRepository.updateCountrie(id, countrie);
        }
    }
}
