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
            var connectionString = SqliteConnectionResolver.BuildConnectionString("Data Source=basen.api.db");
            optionsBuilder.UseSqlite(connectionString,
                b => b.MigrationsAssembly("WebAppBase.Persistence"));
        }
    }
}
