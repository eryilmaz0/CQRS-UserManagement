using AutoMapper;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.Dto;
using UserManagement.Command.Domain.Entity;

namespace UserManagement.Command.Infrastructure.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<CreateUserRoleCommand, UserRole>().ReverseMap();
    }
}