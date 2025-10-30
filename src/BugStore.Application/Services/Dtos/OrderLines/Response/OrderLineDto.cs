using BugStore.Application.Services.Products.Dto.Response;
using BugStore.Domain.Models;

namespace BugStore.Application.Services.Dtos.OrderLines.Response;
public record OrderLineDto(Guid Id, Guid OrderId, int Quantity, decimal Total, Guid ProductId, ProductDto Product);

