using BugStore.Application.Services.Products.Dto.Response;

namespace BugStore.Application.Services.Dtos.OrderLines.Request;
public record OrderLineRequest(Guid OrderId, int Quantity,decimal Total, Guid ProductId, ProductDto ProductDto);

