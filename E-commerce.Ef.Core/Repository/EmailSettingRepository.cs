using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain;
using E_Commrece.Domain.Admin;
using E_Commrece.Domain.services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository
{
    public class EmailSettingRepository : GenericRepository<EmailSetting>, IEmailRepository
    {
        public EmailSettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
