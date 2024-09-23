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
    public class CountrieRepository : ICountrieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CountrieRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Countrie> AddCountrie(Countrie countrie)
        {
            await _applicationDbContext.Countries.AddAsync(countrie);
            await _applicationDbContext.SaveChangesAsync();
            return countrie;
        }

        public async Task<Countrie> DeleteCountrie(int id)
        {
            var DeleteCountrie = await this.GetCountrieById(id);
            _applicationDbContext.Countries.Remove(DeleteCountrie);
            await _applicationDbContext.SaveChangesAsync();
            return DeleteCountrie;
        }

        public async Task<List<Countrie>> GetAllCountries()
        {
            return await _applicationDbContext.Countries.AsNoTracking().ToListAsync();
        }

        public async Task<Countrie> GetCountrieById(int id)
        {
            return await _applicationDbContext.Countries.AsNoTracking().Where(x=>x.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Countrie>> SearchCountries(string SearchString)
        {
            return await _applicationDbContext.Countries.AsNoTracking().Where(x=>x.CountryName == SearchString).ToListAsync();
        }

        public async Task<Countrie> updateCountrie(int id, Countrie countrie)
        {
            var oldcountrie = await this.GetCountrieById(id);
            countrie.id = oldcountrie.id;
            _applicationDbContext.Countries.Update(countrie);
            _applicationDbContext.SaveChanges();
            return countrie;
        }
    }
}
