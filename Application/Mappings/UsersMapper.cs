using Application.DTOs.UsersDtos;
using Application.Features.UsersFeatures.Commands.LoginCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<Users, LoginDto>().ReverseMap();
        CreateMap<LoginCommand, LoginDto>().ReverseMap();
    }
}
