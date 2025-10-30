using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Dtos.OrderLines.Response;

namespace BugStore.Application.Services.Orders.Dto.Request;

public record OrderRequest(Guid Id, Guid CustomerId, CustomerDto CustomerDto,List<OrderLineDto> Lines);
