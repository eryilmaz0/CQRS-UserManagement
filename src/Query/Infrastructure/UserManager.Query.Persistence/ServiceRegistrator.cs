using Microsoft.Extensions.DependencyInjection;
using UserManager.Query.Application.Repository;
using UserManager.Query.Persistence.Mongo;

namespace UserManager.Query.Persistence;

public static class ServiceRegistrator
{
    public static void RegisterPersistenceServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMongoContext, MongoContext>();
        serviceCollection.AddSingleton(typeof(IRepository<,>), typeof(MongoGenericRepository<,>));
        serviceCollection.AddSingleton<IUserRepository, MongoUserRepository>();
        serviceCollection.AddSingleton<IUserRoleRepository, MongoUserRoleRepository>();
    }
}