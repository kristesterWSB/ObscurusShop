using Microsoft.EntityFrameworkCore;
using ObscurusShop.Api.Models;

namespace ObscurusShop.Api.Data
{
    // DbContext reprezentuje sesję z bazą danych
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSet = tabela w bazie
        public DbSet<Guitar> Guitars { get; set; }
    }
}
