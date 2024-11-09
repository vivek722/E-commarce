using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.Email_SMS_Sender
{
    public class SMSsender : ISMSsender
    {
        public Task AddMobileNo(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task SendSmsAsync(string phoneNumber, string message)
        {
            throw new NotImplementedException();
        }
    }
}
