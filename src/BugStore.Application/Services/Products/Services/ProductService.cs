using AutoMapper;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;
using BugStore.Application.Utils;
using BugStore.Domain.Base;
using BugStore.Domain.Models;

namespace BugStore.Application.Services.Products.Services;
public class ProductService(IRepository<Product> _productRepository,
    IMapper _mapper) : IProductService
{
    public Task CreateAsync(ProductDtoRequest customerRequest)
    {
        var entity = _mapper.Map<Product>(customerRequest);
        entity = ProductMethods.CreateProduct(customerRequest);
        return _productRepository.AddAsync(entity);
    }   

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var entities = await _productRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(entities);
    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var entity = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(entity);
    }

    public async Task<ProductDto> UpdateProductAsync(Guid id, ProductDtoRequest productDtoRequest)
    {
        var entity = await _productRepository.GetByIdAsync(id);

        entity.UpdateWith(productDtoRequest.Title, productDtoRequest.Description, productDtoRequest.Price);

        await _productRepository.UpdateAsync(entity);

        return _mapper.Map<ProductDto>(entity);
    }

    public async Task<ProductDto> DeleteProductAsync(Guid id)
    {
        var entity = _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(id);
        return _mapper.Map<ProductDto>(entity);
    }
}
