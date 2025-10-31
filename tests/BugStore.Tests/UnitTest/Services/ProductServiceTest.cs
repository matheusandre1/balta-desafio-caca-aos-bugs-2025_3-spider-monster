using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Services;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Services.Products.Dto.Request;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Tests.UnitTest.Services;
public class ProductServiceTest : IClassFixture<TestFixture>
{
    private readonly IProductService _productService;

    public ProductServiceTest(TestFixture fixture)
    {
        _productService = fixture.ServiceProvider.GetRequiredService<IProductService>();
    }

    [Fact]
    public async Task CreateAsync_ValidProduct_ShouldCreateSuccessfully()
    {

        var productRequest = new ProductDtoRequest
            ("titleTest", "descriptionTeste", "slug-test", 90.90m);

        await _productService.CreateAsync(productRequest);
        var customers = await _productService.GetAllAsync();


        Assert.NotNull(customers);
        Assert.Equal(1, customers.Count());
    }

    [Fact]
    public async Task GetbyIdNotExistingProduct_ShouldThrowException()
    {
        var noexistGuid = Guid.Empty;

        var exception = await Assert.ThrowsAsync<Exception>(() => _productService.GetByIdAsync(noexistGuid));

        Assert.Equal("Product Not Found", exception.Message);
    }


    [Fact]
    public async Task GetAllAsyncProduct_ShouldThrowException()
    {
        var productsNotExisting = await _productService.GetAllAsync();

        Assert.NotNull(productsNotExisting);
        Assert.Equal(0, productsNotExisting.Count());
    }

    [Fact]
    public async Task DeleteByAsyncProduct_ShouldThrowException()
    {
        var notExistGuid = Guid.Empty;

        var exception = await Assert.ThrowsAsync<Exception>(() => _productService.DeleteProductAsync(notExistGuid));

        Assert.Equal("Product Not Found", exception.Message);
    }
}
