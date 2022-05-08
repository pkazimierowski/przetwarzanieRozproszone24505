using Lab2_Kazimierowski.rest.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Kazimierowski.rest.Context
{
    public class AzureDbContext : DbContext
    {
        protected AzureDbContext()
        {
        }

        public AzureDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Person> People { get; set; }
            
    }
}