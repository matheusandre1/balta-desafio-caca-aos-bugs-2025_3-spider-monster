using System.ComponentModel.DataAnnotations;

namespace BugStore.Domain.Models;
public class Order
{
    [Key]
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public DateTime CreatedAt { get; set; }    
    public DateTime UpdateAt { get; set; }
    public List<OrderLine> Lines { get; set; } = null;
}
