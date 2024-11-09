using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.Email_SMS_Sender
{
    public interface ISMSsender
    {
        Task SendSmsAsync(string phoneNumber, string message);
        Task AddMobileNo(string phoneNumber);
    }
}
