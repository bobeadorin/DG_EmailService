namespace EmailService.Services
{
    public interface IEmailService
    {
        public Task SendEmail(string toEmail, string subject, string body, bool isHtml = false);
    }
}
