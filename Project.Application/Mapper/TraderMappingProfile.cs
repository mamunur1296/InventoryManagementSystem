using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.TraderFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class TraderMappingProfile : Profile
    {
        public TraderMappingProfile()
        {
            CreateMap<Trader, TraderModels>().ReverseMap();
            CreateMap<Trader, CreateTraderCommand>().ReverseMap();
            CreateMap<Trader, UpdateTraderCommand>().ReverseMap();
            CreateMap<Trader, TraderDTO>().ReverseMap();
        }
    }
}
