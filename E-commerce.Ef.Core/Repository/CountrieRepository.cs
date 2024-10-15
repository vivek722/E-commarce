using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain;
using E_Commrece.Domain.services.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class CountrieRepository : GenericRepository<Countrie>,ICountrieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CountrieRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Countrie>> SearchCountries(string SearchString)
        {
            return await _applicationDbContext.Countries.AsNoTracking().Where(x=>x.CountryName == SearchString).ToListAsync();
        }
    }
}
