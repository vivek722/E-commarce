using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class AdminRepository : GenericRepository<AdminModel>, IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<AdminModel>> SearchAdmin(string search)
        {
            return _context.Admin.AsNoTracking().Where(x => x.UserName == search).Include(x => x.Role).ToListAsync();
        }
    }
}
