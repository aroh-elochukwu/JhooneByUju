using JhooneByUjuWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JhooneByUjuWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        
    }
}
