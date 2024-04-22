using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.StockFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Mapper
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<Stock, StockModels>().ReverseMap();
            CreateMap<Stock, CreateStockCommand>().ReverseMap();
            CreateMap<Stock, UpdateStockCommand>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
        }
    }
}
