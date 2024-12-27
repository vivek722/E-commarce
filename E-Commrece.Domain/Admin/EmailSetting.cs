using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.Admin
{
    public class EmailSetting : BaseEntityModel
    {
        public string SmtpServer { get; set; }
        public string Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
