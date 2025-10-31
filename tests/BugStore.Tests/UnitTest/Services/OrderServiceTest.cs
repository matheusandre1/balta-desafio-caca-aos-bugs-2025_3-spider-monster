using BugStore.Application.Services.Dtos.OrderLines.Request;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Services.Orders.Dto.Request;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Domain.Base;
using BugStore.Domain.Models;
using BugStore.Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Tests.UnitTest.Services;
public class OrderServiceTest : IClassFixture<TestFixture>
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly IRepository<Order> _orderRepository;
    private readonly AppContextDb _context;

    public OrderServiceTest(TestFixture fixture)
    {
        _orderService = fixture.ServiceProvider.GetRequiredService<IOrderService>();
        _productService = fixture.ServiceProvider.GetRequiredService<IProductService>();
        _orderRepository = fixture.ServiceProvider.GetRequiredService<IRepository<Order>>();
        _context = fixture.ServiceProvider.GetRequiredService<AppContextDb>();
    }

    [Fact]
    public async Task GetbyIdNotExistingOrder_ShouldThrowException()
    {
        var noexistGuid = Guid.Empty;

        var exception = await Assert.ThrowsAsync<Exception>(() => _orderService.GetByIdAsync(noexistGuid));

        Assert.Equal("Order Not Found", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_ValidOrder_ShouldCreateSuccessfully()
    {
        var productRequest = new ProductDtoRequest("Produto Teste", "Descrição", "produto-teste", 10.00m);
        

        await _productService.CreateAsync(productRequest);       

        var products = await _productService.GetAllAsync();
        var product = products.First();

        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(product.Id, 2)

            });

        
        await _orderService.CreateAsync(orderRequest);

        var createOrderId = (await _orderRepository.GetAllAsync()).First().Id;

        var orderWithLines = await _context.Orders.Include(o => o.Lines).FirstAsync(o=> o.Id == createOrderId);

        Assert.Equal(orderRequest.CustomerId,orderWithLines.CustomerId);
        Assert.Single(orderWithLines.Lines);

        var line = orderWithLines.Lines.First();
        Assert.Equal(orderWithLines.Id, line.OrderId);
        Assert.Equal(product.Id, line.ProductId);
        Assert.Equal(2, line.Quantity);
        Assert.Equal(20.00m, line.Total);
    }

    [Fact]
    public async Task CreateAsync_InvalidCustomerId_ShouldThrowException()
    {
        var orderRequest = new OrderRequest(
            CustomerId: Guid.Empty,
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(Guid.NewGuid(), 1)
            });

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.Equal("CustomerId Invalido", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_EmptyLines_ShouldThrowException()
    {
        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>());

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.Equal("Pedido deve conter ao menos um linha", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_InvalidProductId_ShouldThrowException()
    {
        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(Guid.Empty, 1)
            });

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.Equal("ProductId Invalido na linha do pedido", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_ZeroQuantity_ShouldThrowException()
    {
        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(Guid.NewGuid(), 0)
            });

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.Equal("Quantidade deve ser maior que zero na linha do pedido", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_NegativeQuantity_ShouldThrowException()
    {
        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(Guid.NewGuid(), -1)
            });

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.Equal("Quantidade deve ser maior que zero na linha do pedido", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_ProductNotFound_ShouldThrowException()
    {
        var missingProductId = Guid.NewGuid();
        var orderRequest = new OrderRequest(
            CustomerId: Guid.NewGuid(),
            Lines: new List<OrderLineRequest>
            {
                new OrderLineRequest(missingProductId, 1)
            });

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _orderService.CreateAsync(orderRequest));

        Assert.StartsWith("Produto com Id", exception.Message);
        Assert.EndsWith("nao encontrado", exception.Message);
    }
}
