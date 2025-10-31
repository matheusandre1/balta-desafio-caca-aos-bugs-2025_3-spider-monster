using AutoMapper;
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Dtos.OrderLines.Request;
using BugStore.Application.Services.Dtos.OrderLines.Response;
using BugStore.Application.Services.Orders.Dto.Request;
using BugStore.Application.Services.Orders.Dto.Response;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;
using BugStore.Domain.Models;

namespace BugStore.Application.Services;
public class MappingProfile : Profile
{
    public MappingProfile() {

        CreateMap<Customer, CustomerDto>();

        CreateMap<CustomerDtoRequest, Customer>().ForMember(d=>d.Id, opt=>opt.Ignore());

        CreateMap<Product, ProductDto>();

        CreateMap<ProductDtoRequest, Product>().ForMember(d=>d.Id, opt=>opt.Ignore());

        CreateMap<OrderLine, OrderLineDto>();

        CreateMap<OrderLineRequest, OrderLine>()
            .ForMember(d=>d.Id, opt=>opt.Ignore())
            .ForMember(d=>d.Total, opt=>opt.Ignore());

        CreateMap<Order, OrderDto>();

        CreateMap<OrderRequest, Order>()
            .ForMember(d=>d.Id, opt=>opt.Ignore())
            .ForMember(d=>d.CreatedAt, opt=>opt.Ignore())
            .ForMember(d=>d.UpdateAt, opt=>opt.Ignore());
    }
}
