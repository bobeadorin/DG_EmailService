using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace EmailService.Constant
{
    public class AccountActivationEmail
    {
        public const string Subject = "Activate Your DailyGrind Account";
    }

    public class HtmlFilesPath
    {
        public static string AccountValidationHtml = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "EmailHtmlPage",
            "AccountValidationEmailHtml.html"
        );
    }
}
