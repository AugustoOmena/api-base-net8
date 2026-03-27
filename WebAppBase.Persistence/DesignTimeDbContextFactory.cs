using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebAppBase.Persistence.Context;

namespace WebAppBase.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = SqliteConnectionResolver.BuildConnectionString("Data Source=basen.api.db");

        builder.UseSqlite(connectionString);

        return new AppDbContext(builder.Options);
    }
}