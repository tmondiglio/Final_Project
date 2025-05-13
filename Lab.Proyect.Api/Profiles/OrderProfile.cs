using AutoMapper;
using Lab.Project.Api.DTOs;
using Lab.Project.Application.Dto;
using Lab.Project.Domain.Entities;

namespace Lab.Project.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderRequest, OrderDto>();
            CreateMap<CreateOrderItemRequest, OrderItemDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
