
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Interfaces;
using BugStore.Tests.UnitTest;
using Microsoft.Extensions.DependencyInjection;

public class CustomerServiceTests : IClassFixture<TestFixture>
{
    private readonly ICustomerService _customerService;

    public CustomerServiceTests(TestFixture fixture)
    {
        _customerService = fixture.ServiceProvider.GetRequiredService<ICustomerService>();
    }

    [Fact]
    public async Task CreateAsync_ValidCustomer_ShouldCreateSuccessfully()
    {
        
        var customerRequest = new CustomerDtoRequest("João Silva", "joao@teste.com", "11999999999", new DateTime(1990, 1, 1));
       
        
        await _customerService.CreateAsync(customerRequest);
        var customers = await _customerService.GetAllAsync();

        
        Assert.NotNull(customers);       
    }

    [Fact]
    public async Task GetbyIdNotExistingCustomer_ShouldThrowException()
    {
        var noexistGuid = Guid.Empty;

        var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.GetByIdAsync(noexistGuid));

        Assert.Equal("Customer not found", exception.Message);        
    }

    [Fact]
    public async Task GetAllAsyncCustomers_ShouldThrowException()
    {
        var customersNotExisting = await _customerService.GetAllAsync();

        Assert.NotNull(customersNotExisting);
        Assert.Equal(0, customersNotExisting.Count());
    }

    [Fact]

    public async Task DeleteByAsyncCustomers_ShouldThrowException() 
    {
        var notExistGuid = Guid.Empty;        

        var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.DeleteCustomerAsync(notExistGuid));

        Assert.Equal("Customer not found", exception.Message);
    }
}
