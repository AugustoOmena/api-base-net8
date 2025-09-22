using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebAppBase.Persistence.Context;

namespace WebAppBase.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        builder.UseSqlite("Data Source=../WebAppBase.Persistence/app.db");

        return new AppDbContext(builder.Options);
    }
}