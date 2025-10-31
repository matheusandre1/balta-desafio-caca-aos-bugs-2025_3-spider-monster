namespace BugStore.Application.Services.Customers.Dto.Response;

public record CustomerDto(Guid id, string Name, string Email, string Phone, DateTime BirthDate);