using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Command.API.ConfigurationModel;
using UserManagement.Command.Application.Repository;
using UserManagement.Command.Persistence.Context;
using UserManagement.Command.Persistence.Repository.EntityFramework;
using UserManagement.Command.Persistence.Repository.EntityFramework.PostgreSql;

namespace UserManagement.Command.Persistence;

public static class ServiceRegistrator
{
    //Passing ConnectionString as a parameter
    public static void RegisterPersistenceServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfBaseRepository<>));
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserRoleRepository, UserRoleRepository>();
        serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
    }
}