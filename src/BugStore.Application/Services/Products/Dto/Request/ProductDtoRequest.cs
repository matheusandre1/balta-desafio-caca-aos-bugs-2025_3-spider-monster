namespace BugStore.Application.Services.Products.Dto.Request;

public record ProductDtoRequest(string? Title, string? Description, string? Slug, decimal Price);
