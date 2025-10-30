using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Dtos.OrderLines.Response;

namespace BugStore.Application.Services.Orders.Dto.Response;

public record OrderDto(Guid Id, Guid CustomerId, CustomerDto Customer, DateTime CreatedAt, DateTime UpdatedAt, List<OrderLineDto> Lines);