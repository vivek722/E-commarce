using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;

namespace E_commarceWebApi.Controllers
{
    public class Email_SMSController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Email_SMSController(IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _env = hostEnvironment;
            _configuration = configuration;
        }
        [HttpPost("EmailSending")]
        public async Task<IActionResult> EmailSending()
        {
            var Email = new MimeMessage();
            var port = int.Parse(_configuration["EmailSettings:port"]);
            var FromEmailAddress = _configuration["EmailSettings:EmailAddress"];
            var server = _configuration["EmailSettings:smtpServer"];
            var Password = _configuration["EmailSettings:Password"];
            Email.From.Add(MailboxAddress.Parse(FromEmailAddress));
            Email.To.Add(MailboxAddress.Parse("vivekthakkar166@gmail.com"));
            Email.Subject = "<h1>Hii This Only test</h1>";
            Email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<h1>Hii This Only test</h1>"
            };
            var bodybuidlder = new BodyBuilder();
            Email.Body = bodybuidlder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(server, port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(FromEmailAddress, Password);
            smtp.Send(Email);
            smtp.Disconnect(true);
            return Ok();
            }
    }
}
