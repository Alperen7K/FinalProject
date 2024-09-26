using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

// context nesnesi db tabloları ile proje class'larını bağlar
public class SqlContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=FinalProject");
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }
}