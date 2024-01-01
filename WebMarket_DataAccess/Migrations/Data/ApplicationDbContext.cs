using Microsoft.EntityFrameworkCore;
using WebMarket_Models;

namespace WebMarket_App.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {     
        }
        public DbSet<Category> Categories { get; set; }
    }
}
