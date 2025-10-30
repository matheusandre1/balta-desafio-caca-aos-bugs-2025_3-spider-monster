using System.ComponentModel.DataAnnotations;

namespace BugStore.Domain.Models;


public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime BirthDate { get; set; } 
}
