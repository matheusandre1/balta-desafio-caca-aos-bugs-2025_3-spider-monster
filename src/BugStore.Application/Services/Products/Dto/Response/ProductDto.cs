namespace BugStore.Application.Services.Products.Dto.Response;

public record ProductDto(Guid Id, string Title, string? Description, string? Slug, decimal Price);