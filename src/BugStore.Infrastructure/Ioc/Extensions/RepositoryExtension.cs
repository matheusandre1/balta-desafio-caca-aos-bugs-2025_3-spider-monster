using BugStore.Domain.Base;
using BugStore.Infra.Context;
using BugStore.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Infra.IoC;

public static class InfraServiceCollectionExtensions
{
    public static IServiceCollection AddInfraPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? "Data Source=bugstore.db";

        services.AddDbContext<AppContextDb>(options =>
        {
            options.UseSqlite(connectionString);           
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}