﻿using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;

namespace BugStore.Application.Services.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid id);
    Task CreateAsync(ProductDtoRequest customerRequest);
    Task<ProductDto> UpdateProductAsync(Guid id, ProductDtoRequest dto);
    Task<ProductDto> DeleteProductAsync(Guid id);
}
