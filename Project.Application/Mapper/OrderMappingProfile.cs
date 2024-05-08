using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() {
            CreateMap<Order, OrderModels>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
