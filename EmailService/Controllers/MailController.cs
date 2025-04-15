using EmailService.Constant;
using EmailService.Models;
using EmailService.Services;
using EmailService.Utillity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public MailController(ILogger<MailController> logger, IEmailService emailService, IConfiguration config)
        {
            _logger = logger;
            _emailService = emailService;
            _config = config;
        }

        [HttpPost("/SendRegistrationMail")]
        public IActionResult SendAccountActivationEmail([FromBody] UserRegistrationData userData)
        {
            try
            {
                string activationLink = ApiEndpoints.ActivateAccount + userData.Token;

                var message = HtmlParser.ReadAndReplace(HtmlFilesPath.AccountValidationHtml, activationLink);


                _emailService.SendEmail(userData.ToEmail, AccountActivationEmail.Subject, message, isHtml: true);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
