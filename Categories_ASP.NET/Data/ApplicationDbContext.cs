using Categories_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Categories_ASP.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
    }
}
