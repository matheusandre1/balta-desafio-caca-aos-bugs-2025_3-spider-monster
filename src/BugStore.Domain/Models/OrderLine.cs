using System.ComponentModel.DataAnnotations;

namespace BugStore.Domain.Models;
public class OrderLine
{

    [Key]
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
