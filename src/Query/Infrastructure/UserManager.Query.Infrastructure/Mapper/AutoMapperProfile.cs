using AutoMapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Infrastructure.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, ListUsersViewModel>().ReverseMap();
        CreateMap<User, GetUserWithDetailViewModel>().ReverseMap();
        CreateMap<User, GetUserAddressViewModel>().ReverseMap();
        CreateMap<User, ListUsersViewModel>().ReverseMap();
    }
}