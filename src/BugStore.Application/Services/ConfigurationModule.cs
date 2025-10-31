using BugStore.Application.Services.Customers.Services;
using BugStore.Application.Services.Orders.Services;
using BugStore.Application.Services.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Application.Services;
public static class ConfigurationModule
{
    
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddScoped<Interfaces.ICustomerService, CustomerService>();
        services.AddScoped<Interfaces.IProductService, ProductService>();
        services.AddScoped<Interfaces.IOrderService, OrderService>();
        return services;
    }
   
}