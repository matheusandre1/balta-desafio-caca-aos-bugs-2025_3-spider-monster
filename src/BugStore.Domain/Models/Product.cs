using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace BugStore.Domain.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public decimal Price { get; set; }
    
    public void UpdateWith(string? title, string? description, decimal price) 
    {
        if (title != null) Title = title;
        if (description != null) Description = description;
        Price = price;
    }
}