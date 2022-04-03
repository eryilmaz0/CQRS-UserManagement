using Microsoft.Extensions.DependencyInjection;
using UserManager.Query.Application.BusinessService;

namespace UserManager.Query.Application;

public static class ServiceRegistrator
{
    public static void RegisterApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton<IUserRoleService, UserRoleService>();
        serviceCollection.AddSingleton<IAddressService, AddressService>();
        serviceCollection.AddSingleton<IEventHandleService, EventHandlerService>();
    }
}