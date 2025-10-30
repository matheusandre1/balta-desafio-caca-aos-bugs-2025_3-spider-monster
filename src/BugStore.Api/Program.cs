using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using BugStore.Application.Services;
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Dtos.OrderLines.Request;
using BugStore.Application.Services.Dtos.OrderLines.Response;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Services.Orders.Dto.Request;
using BugStore.Application.Services.Orders.Dto.Response;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;
using BugStore.Infra.IoC;



var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddApplicationModule();
builder.Services.AddInfraPersistence(builder.Configuration);
builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

var customers = app.MapGroup("v1/customers");
var products = app.MapGroup("v1/products");
var orders = app.MapGroup("v1/orders");

#region Customer

customers.MapGet("/", async (ICustomerService service) =>
{
    var customers = await service.GetAllAsync();

    return customers is not null ? Results.Ok(customers) : Results.NoContent();

});

customers.MapGet("/{id:guid}", async (ICustomerService service, Guid id) =>
{
    var customer = await service.GetByIdAsync(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

customers.MapPost("/", async (ICustomerService service, CustomerDtoRequest customerDtoRequest) =>
{
    await service.CreateAsync(customerDtoRequest);
    return Results.Created($"/v1/customers/{customerDtoRequest}", customerDtoRequest);
});

customers.MapPut("/{id:guid}", async (ICustomerService service, Guid id, CustomerDtoRequest customerDtoRequest) =>
{
    var updatedCustomer = await service.UpdateCustomerAsync(id, customerDtoRequest);
    return updatedCustomer is not null ? Results.Ok(updatedCustomer) : Results.NotFound();
});

customers.MapDelete("/{id:guid}", async (ICustomerService service, Guid id) =>
{
    var deletedCustomer = await service.DeleteCustomerAsync(id);
    return deletedCustomer is not null ? Results.Ok(deletedCustomer) : Results.NotFound();
});

#endregion 

#region Products

products.MapGet("/", async (IProductService service) =>
{
    var products = await service.GetAllAsync();
    return products is not null ? Results.Ok(products) : Results.NoContent();
});

products.MapGet("/{id:guid}", async (IProductService service, Guid id) =>
{
    var product = await service.GetByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

products.MapPost("/", async (IProductService service, ProductDtoRequest productDtoRequest) =>
{
    await service.CreateAsync(productDtoRequest);
    return Results.Created($"/v1/products/{productDtoRequest}", productDtoRequest);
});

products.MapPut("/{id:guid}", async (IProductService service, Guid id, ProductDtoRequest productDtoRequest) =>
{
    var updatedProduct = await service.UpdateProductAsync(id, productDtoRequest);
    return updatedProduct is not null ? Results.Ok(updatedProduct) : Results.NotFound();
});

products.MapDelete("/{id:guid}", async (IProductService service, Guid id) =>
{
    var deletedProduct = await service.DeleteProductAsync(id);
    return deletedProduct is not null ? Results.Ok(deletedProduct) : Results.NotFound();
});
#endregion

#region Order

orders.MapGet("/{id:guid}", async (IOrderService service, Guid id) =>
{
    var order = await service.GetByIdAsync(id);
    return products is not null ? Results.Ok(products) : Results.NoContent();
});

orders.MapPost("/", async (IOrderService service, OrderRequest orderRequest) =>
{
    await service.CreateAsync(orderRequest);
    return Results.Created($"/v1/orders/{orderRequest}", orderRequest);
});
#endregion

app.Run();



[JsonSerializable(typeof(CustomerDto))]
[JsonSerializable(typeof(CustomerDtoRequest))]
[JsonSerializable(typeof(OrderLineRequest))]
[JsonSerializable(typeof(OrderLineRequest[]))]
[JsonSerializable(typeof(OrderLineDto))]
[JsonSerializable(typeof(OrderRequest))]
[JsonSerializable(typeof(OrderDto))]
[JsonSerializable(typeof(ProductDto))]
[JsonSerializable(typeof(ProductDtoRequest))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}