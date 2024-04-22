using AutoMapper;
using Project.Application.DTOs;
using Project.Application.Features.UserFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Entities;


namespace Project.Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModels>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
