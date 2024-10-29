using E_commerce.Ef.Core.Repository.Base;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain;
using E_Commrece.Domain.services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class AddressRepository : GenericRepository<Addresse>
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<List<Addresse>> SearchCountries(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
