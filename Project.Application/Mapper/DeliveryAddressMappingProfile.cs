using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class DeliveryAddressMappingProfile : Profile
    {
        public DeliveryAddressMappingProfile()
        {
            CreateMap<DeliveryAddress, DeliveryAddressModels>().ReverseMap();
            CreateMap<DeliveryAddress, DeliveryAddressDTO>().ReverseMap();
        }
    }
}
