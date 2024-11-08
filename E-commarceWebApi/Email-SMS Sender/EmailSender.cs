using MimeKit;
using System.Threading.Tasks;

namespace E_Commrece.Domain.Email_SMS_Sender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string UserName)
        {
            var Email = new MimeMessage();
            var port = int.Parse(_configuration["EmailSettings:port"]);
            var FromEmailAddress = _configuration["EmailSettings:EmailAddress"];
            var server = _configuration["EmailSettings:smtpServer"];
            var Password = _configuration["EmailSettings:Password"];
            Email.From.Add(MailboxAddress.Parse(FromEmailAddress));
            Email.To.Add(MailboxAddress.Parse(email));
            Email.Subject = subject;
            var emailBody = "";
            if (subject == "Welcome to Our ShopMart!")
            {
                emailBody = GetUserWelcomeEmail(UserName);
            }
            else if(subject == "Thank You To Join Our ShopMart!")
            {
                emailBody = GetSupplierWelcomeEmail(UserName);
            }
            Email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailBody 
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(server, port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(FromEmailAddress, Password);
            smtp.Send(Email);
            smtp.Disconnect(true);
        }

        public string GetUserWelcomeEmail(string UserName)
        {
            var WelcomeEmailBody = @"

                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Welcome to ShopMart</title>
                </head>
                <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                    <table width='100%' cellpadding='0' cellspacing='0' style='max-width: 600px; margin: auto; background-color: #ffffff;'>
                        <tr>
                            <td style='padding: 20px; text-align: center; background-color: #4CAF50; color: #ffffff;'>
                                <h1>Welcome to ShopMart</h1>
                            </td>
                        </tr>
                        <tr>
                            <td style='padding: 20px;'>
                                <p>Hi [FirstName],</p>
                                <p>Welcome to the <strong>ShopMart</strong> family! We’re thrilled to have you on board and can’t wait for you to explore the amazing products, exclusive deals, and personalized shopping experience waiting for you.</p>
                
                                <h2>Here’s what you can do with your new account:</h2>
                                <ul>
                                    <li><strong>Explore New Products:</strong> Dive into a wide variety of categories to find everything you need (and a little something extra).</li>
                                    <li><strong>Get Exclusive Offers:</strong> As a member, you’ll receive special promotions and early access to sales. Check your inbox regularly to stay updated.</li>
                                    <li><strong>Track Your Orders:</strong> Easily manage your orders, track shipping, and review your purchase history.</li>
                                    <li><strong>Save Your Favorites:</strong> Love something? Save it to your wishlist and revisit anytime.</li>
                                </ul>

                                <h2>Getting Started is Easy:</h2>
                                <ol>
                                    <li><strong>Log in to Your Account:</strong> <a href='[Login Link]'>Login Here</a></li>
                                    <li><strong>Complete Your Profile:</strong> Update your shipping and payment details for faster checkout.</li>
                                    <li><strong>Start Shopping:</strong> Browse our latest arrivals and seasonal offers!</li>
                                </ol>

                                <p>If you need any assistance, our support team is here to help! Just reply to this email or visit our <a href='[Contact Us Page Link]'>Contact Us Page</a>.</p>

                                <p>Once again, welcome to the ShopMart family! We’re excited to be part of your shopping journey.</p>

                                <p>Happy Shopping!</p>

                                <p>Best regards,<br>The ShopMart Team</p>
                            </td>
                        </tr>
                        <tr>
                            <td style='padding: 20px; text-align: center; background-color: #f1f1f1; color: #888;'>
                                <p>&copy; [Year] [Your E-Commerce Website Name]. All rights reserved.</p>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>";

            WelcomeEmailBody = WelcomeEmailBody
                .Replace("[FirstName]", UserName)
                .Replace("[Login Link]", _configuration["EmailSettings:LoginLink"])  
                .Replace("[Contact Us Page Link]", _configuration["EmailSettings:ContactUsPageLink"])  
                .Replace("[Year]", DateTime.Now.Year.ToString())
                .Replace("[Your E-Commerce Website Name]", _configuration["EmailSettings:WebsiteName"]);  

            return WelcomeEmailBody;
        }
        public string GetSupplierWelcomeEmail(string SupplierName)
        {
            var WelcomeEmailBody = @"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Welcome to [Your Company] Supplier Program</title>
            </head>
            <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                <table width='100%' cellpadding='0' cellspacing='0' style='max-width: 600px; margin: auto; background-color: #ffffff;'>
                    <tr>
                        <td style='padding: 20px; text-align: center; background-color: #4CAF50; color: #ffffff;'>
                            <h1>Welcome to [Your Company] Supplier Program</h1>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px;'>
                            <p>Dear [SupplierName],</p>
                            <p>Congratulations and welcome to the <strong>[Your Company]</strong> supplier network! We are thrilled to have you on board and look forward to a successful partnership with your company.</p>

                            <h2>What to Expect:</h2>
                            <ul>
                                <li><strong>Manage Your Products:</strong> Easily add, update, and manage your product listings on our platform.</li>
                                <li><strong>Track Your Orders:</strong> Monitor and manage orders with ease using our intuitive dashboard.</li>
                                <li><strong>Exclusive Offers:</strong> Access exclusive supplier offers and promotions that will help boost your sales.</li>
                                <li><strong>Customer Insights:</strong> Gain valuable insights into customer preferences to optimize your product offerings.</li>
                            </ul>

                            <h2>Getting Started:</h2>
                            <ol>
                                <li><strong>Activate Your Account:</strong> Click the link below to activate your supplier account:</li>
                                <li><a href='[ActivationLink]' style='color: #4CAF50; font-weight: bold;'>Activate Your Account</a></li>
                                <li><strong>Complete Your Profile:</strong> Fill in your company details and product information.</li>
                                <li><strong>Start Selling:</strong> Begin listing your products and connect with customers.</li>
                            </ol>

                            <p>If you have any questions or need assistance, our support team is here to help. Just reply to this email or visit our <a href='[SupportPageLink]' style='color: #4CAF50;'>Support Page</a>.</p>

                            <p>We look forward to building a great relationship with you and helping you grow your business.</p>

                            <p>Best regards,<br>The [Your Company] Team</p>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px; text-align: center; background-color: #f1f1f1; color: #888;'>
                            <p>&copy; [Year] [Your Company]. All rights reserved.</p>
                        </td>
                    </tr>
                </table>

            </body>
            </html>";

            WelcomeEmailBody = WelcomeEmailBody
                .Replace("[SupplierName]", SupplierName)
                .Replace("[ActivationLink]", _configuration["EmailSettings:ActivationLink"])
                .Replace("[SupportPageLink]", _configuration["EmailSettings:SupportPageLink"])
                .Replace("[Year]", DateTime.Now.Year.ToString())
                .Replace("[Your Company]", _configuration["EmailSettings:CompanyName"]);

            return WelcomeEmailBody;
        }
        public string GetOrderConfirmationEmail(string userName, string orderId,  decimal orderTotal)
        {
            var orderConfirmationEmailBody = @"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Order Confirmation - [Your Company]</title>
                    </head>
                    <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                        <table width='100%' cellpadding='0' cellspacing='0' style='max-width: 600px; margin: auto; background-color: #ffffff;'>
                            <tr>
                                <td style='padding: 20px; text-align: center; background-color: #4CAF50; color: #ffffff;'>
                                    <h1>Thank You for Your Order!</h1>
                                </td>
                            </tr>
                            <tr>
                                <td style='padding: 20px;'>
                                    <p>Dear [UserName],</p>
                                    <p>Thank you for shopping with <strong>[Your Company]</strong>! We’re excited to let you know that we’ve received your order and are already preparing it for shipment.</p>
                
                                    <h2>Order Details:</h2>
                                    <p><strong>Order ID:</strong> [OrderId]</p>
                                    <p><strong>Order Date:</strong> [OrderDate]</p>
                                    <p><strong>Order Total:</strong> $[OrderTotal]</p>

                                    <h2>What Happens Next?</h2>
                                    <p>You’ll receive an email with tracking details once your order has shipped. In the meantime, you can:</p>
                                    <ul>
                                        <li><a href='[TrackOrderLink]' style='color: #4CAF50; font-weight: bold;'>Track Your Order</a></li>
                                        <li><a href='[SupportPageLink]' style='color: #4CAF50;'>Contact Support</a> if you have any questions</li>
                                    </ul>

                                    <p>We hope you enjoy your purchase! Thank you again for choosing us.</p>

                                    <p>Best regards,<br>The [Your Company] Team</p>
                                </td>
                            </tr>
                            <tr>
                                <td style='padding: 20px; text-align: center; background-color: #f1f1f1; color: #888;'>
                                    <p>&copy; [Year] [Your Company]. All rights reserved.</p>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>";
            orderConfirmationEmailBody = orderConfirmationEmailBody
                .Replace("[UserName]", userName) 
                .Replace("[OrderId]", orderId.ToString())  
                .Replace("[OrderDate]", DateTime.Now.ToString())  
                .Replace("[OrderTotal]", orderTotal.ToString("F2"))  
                .Replace("[TrackOrderLink]", _configuration["EmailSettings:TrackOrderLink"])  
                .Replace("[SupportPageLink]", _configuration["EmailSettings:SupportPageLink"])  
                .Replace("[Year]", DateTime.Now.Year.ToString()) 
                .Replace("[Your Company]", _configuration["EmailSettings:CompanyName"]);  

            return orderConfirmationEmailBody;
        }
        public string GetNewSaleNotificationEmail(string saleName, decimal discountAmount, string saleLink)
        {
            var saleNotificationEmailBody = @"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>New Sale at [Your Company]</title>
                </head>
                <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                    <table width='100%' cellpadding='0' cellspacing='0' style='max-width: 600px; margin: auto; background-color: #ffffff;'>
                        <tr>
                            <td style='padding: 20px; text-align: center; background-color: #4CAF50; color: #ffffff;'>
                                <h1>Don’t Miss Our Latest Sale!</h1>
                            </td>
                        </tr>
                        <tr>
                            <td style='padding: 20px;'>
                                <p>Dear Valued Customer,</p>
                                <p>We’re excited to announce our latest sale at <strong>[Your Company]</strong>! Now is the perfect time to grab amazing deals on your favorite products.</p>

                                <h2>Sale Details:</h2>
                                <p><strong>Sale Name:</strong> [SaleName]</p>
                                <p><strong>Discount:</strong> [DiscountAmount]% Off</p>

                                <h2>How to Shop:</h2>
                                <p>Visit the link below to check out the sale and start saving:</p>
                                <p><a href='[SaleLink]' style='color: #4CAF50; font-weight: bold;'>Shop the Sale Now</a></p>

                                <p>Hurry! The sale ends soon. Don't miss out!</p>

                                <p>Best regards,<br>The [Your Company] Team</p>
                            </td>
                        </tr>
                        <tr>
                            <td style='padding: 20px; text-align: center; background-color: #f1f1f1; color: #888;'>
                                <p>&copy; [Year] [Your Company]. All rights reserved.</p>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>";

            saleNotificationEmailBody = saleNotificationEmailBody
                .Replace("[SaleName]", saleName)  
                .Replace("[DiscountAmount]", discountAmount.ToString("F0"))  
                .Replace("[SaleLink]", saleLink)  
                .Replace("[Year]", DateTime.Now.Year.ToString())  
                .Replace("[Your Company]", _configuration["EmailSettings:CompanyName"]);  

            return saleNotificationEmailBody;
        }


    }
}
