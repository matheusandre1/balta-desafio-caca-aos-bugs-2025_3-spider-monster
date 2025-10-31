using BugStore.Application.Services;
using BugStore.Domain.Base;
using BugStore.Infra.Context;

namespace BugStore.Tests.UnitTest;
using global::BugStore.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


public class TestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; }

    public TestFixture()
    {
        var services = new ServiceCollection();
        
        services.AddApplicationModule();
        
        services.AddDbContext<AppContextDb>(options =>
        {
            options.UseInMemoryDatabase($"BugStoreTestsDb_{Guid.NewGuid()}");
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        ServiceProvider.Dispose();
    }
}
