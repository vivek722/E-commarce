using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.User
{
    public class CountrieService : GenericService<Countrie>,ICountrieService
    {
        private readonly ICountrieRepository _countrieRepository;

        public CountrieService(ICountrieRepository countrieRepository) : base(countrieRepository)
        {
            _countrieRepository = countrieRepository;
        }
        public Task<List<Countrie>> SearchCountries(string SearchString)
        {
            return _countrieRepository.SearchCountries(SearchString);
        }
    }
}
