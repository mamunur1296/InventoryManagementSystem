using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.ProductSizeFeatures.Commands;
using Project.Application.Features.RetailerFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class RetaileMappingProfile : Profile
    {
        public RetaileMappingProfile() {
            CreateMap<Retailer, RetailerModel>().ReverseMap();
            CreateMap<Retailer, CreateRetailerCommand>().ReverseMap();
            CreateMap<Retailer, UpdateRetailerCommand>().ReverseMap();
            CreateMap<Retailer, RetailerDTO>().ReverseMap();

        }
    }
}
