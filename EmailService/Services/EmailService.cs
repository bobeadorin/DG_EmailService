using System.Net;
using EmailService.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using EmailService.Constant;
using EmailService.Utillity;

namespace EmailService.Services
{
    public class EmailService: IEmailService
    {
        private readonly SmtpSettings _emailSettings;

        public EmailService(IOptions<SmtpSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value ?? throw new ArgumentNullException(nameof(emailOptions));

        }

        public async Task SendEmail(string toEmail, string subject, string body, bool isHtml = false)
        {
            try
            {
                using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                    client.EnableSsl = _emailSettings.EnableSsl;


                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_emailSettings.Username),
                        Subject = AccountActivationEmail.Subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };

                    mailMessage.To.Add(toEmail);
                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
           
        }


    }
}
