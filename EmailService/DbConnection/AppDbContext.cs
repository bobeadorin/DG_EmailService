using EmailService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailService.DbConnection
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountValidationTokens>();

        }

        public DbSet<AccountValidationTokens> AccountValidationTokens { get;set; }


    }
}
