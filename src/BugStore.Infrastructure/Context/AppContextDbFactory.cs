using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BugStore.Infra.Context;
public class AppContextDbFactory : IDesignTimeDbContextFactory<AppContextDb>
{
    public AppContextDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppContextDb>();

        var connection = Environment.GetEnvironmentVariable("ConnectionStrings__Default") 
            ?? "Data Source=bugstore.db";

        optionsBuilder.UseSqlite(connection);
        optionsBuilder.UseModel(AppContextDbModel.Instance);

        return new AppContextDb(optionsBuilder.Options);
    }
}
