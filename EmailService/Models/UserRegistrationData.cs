namespace EmailService.Models
{
    public class UserRegistrationData
    {
        public string Token { get; set; }
        public string ActivateUrl { get; set; }
        public string ToEmail { get; set; }

    }
}
