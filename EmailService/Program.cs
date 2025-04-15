
using EmailService.Utillity;
using Microsoft.EntityFrameworkCore;
using EmailService.DbConnection;
using EmailService.Services;
using EmailService.Models;


namespace EmailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            //Add logging
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            //Configuration
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
            });

            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));



            //Service registration
            builder.Services.AddTransient<IEmailService,Services.EmailService>();


            //get current IPv4
            var myIp = LocalInfo.GetLocalIP();
            var url = $"http://{myIp}:5219";


            builder.WebHost.UseUrls(url);

            var app = builder.Build();

            var logger = app.Logger;

            logger.LogInformation($"Application will run on: {url}");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            
            logger.LogInformation("Application starting up.");

            app.Run();
        }
    }
}
