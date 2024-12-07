using Microsoft.EntityFrameworkCore;
using WebAppBase.Domain.Entities;

namespace WebAppBase.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=basen.api; Username=postgres; Password=123456", 
                b => b.MigrationsAssembly("WebAppBase.Persistence"));
        }
    }
}
