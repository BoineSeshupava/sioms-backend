using AutoMapper;
using SIOMS.Application.DTOs;
using SIOMS.Domain.Entities;

namespace SIOMS.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InventoryItem, InventoryItemDto>().ReverseMap();
            CreateMap<Site, SiteDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap(); // <-- Add this line
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
