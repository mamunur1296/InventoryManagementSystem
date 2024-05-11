using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class RetaileMappingProfile : Profile
    {
        public RetaileMappingProfile() {
            CreateMap<Retailer, RetailerModel>().ReverseMap();
            CreateMap<Retailer, RetailerDTO>().ReverseMap();

        }
    }
}
