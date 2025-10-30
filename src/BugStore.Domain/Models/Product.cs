using System.ComponentModel.DataAnnotations;

namespace BugStore.Domain.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public decimal Price { get; set; }    
}