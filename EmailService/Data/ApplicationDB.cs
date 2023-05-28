
using EmailService.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB>options): base(options)
        {
        }

        public DbSet<EmailRES>EmailResponse { get; set; } 
    }
}
  