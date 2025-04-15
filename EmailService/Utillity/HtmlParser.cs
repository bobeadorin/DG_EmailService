namespace EmailService.Utillity
{
    public static class HtmlParser
    {
        public static string ReadAndReplace(string htmlPath,string activationLink )
        {
            try
            {
                var htmlContent = File.ReadAllText(htmlPath).Replace("{{ACTIVATION_LINK}}", activationLink);

                return htmlContent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
