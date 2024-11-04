using AutoMapper;
using Ecommerce.Order.API.Models;

namespace Ecommerce.Order.API.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Order, OrderDto>();
            CreateMap<OrderDto, Entities.Order>();

            CreateMap<Entities.OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, Entities.OrderItem>();

            CreateMap<Entities.Order, OrderModel>();
            CreateMap<OrderModel, Entities.Order>();

            CreateMap<Entities.OrderItem, OrderItemModel>();
            CreateMap<OrderItemModel, Entities.OrderItem>();
        }
    }
}
