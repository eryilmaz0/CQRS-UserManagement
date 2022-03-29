using Microsoft.Extensions.DependencyInjection;
using UserManagement.Command.Application.BusinessService;

namespace UserManagement.Command.Application;

public static class ServiceRegistrator
{
    public static void RegisterApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserRoleService, UserRoleService>();
        serviceCollection.AddScoped<IAddressService, AddressService>();
    }
}