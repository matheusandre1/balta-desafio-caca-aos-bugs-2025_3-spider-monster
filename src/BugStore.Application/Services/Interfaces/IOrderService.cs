﻿using BugStore.Application.Services.Orders.Dto.Request;
using BugStore.Application.Services.Orders.Dto.Response;

namespace BugStore.Application.Services.Interfaces;
public interface IOrderService
{
    Task<OrderDto> GetByIdAsync(Guid id);
    Task CreateAsync(OrderRequest orderRequest);    
}
