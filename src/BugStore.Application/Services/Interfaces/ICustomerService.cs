using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Dto.Response;

namespace BugStore.Application.Services.Interfaces;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(Guid id);
    Task CreateAsync(CustomerDtoRequest customerRequest);
    Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerDtoRequest dto);
    Task DeleteCustomerAsync(Guid id);
}
