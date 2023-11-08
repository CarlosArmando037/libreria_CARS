using Librerias_CARS.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Librerias_CARS.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
