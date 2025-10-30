using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Domain.Models;

namespace BugStore.Application.Utils;
public static class ProductMethods
{
    public static Product CreateProduct(ProductDtoRequest request)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Slug = request.Slug,
            Price = request.Price
        };        
    }    
}
