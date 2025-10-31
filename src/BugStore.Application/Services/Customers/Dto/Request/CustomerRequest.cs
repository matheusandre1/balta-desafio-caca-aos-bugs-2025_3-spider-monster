namespace BugStore.Application.Services.Customers.Dto.Request;

public record CustomerDtoRequest(string? Name, string? Email, string? Phone, DateTime? BirthDate);
