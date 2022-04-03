using System.Reflection;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserManagement.Common.Mapper;
using UserManagement.Common.Mediator;
using UserManager.Query.Application.Cache;
using UserManager.Query.Application.Configuration;
using UserManager.Query.Application.QueryCacheManager;
using UserManager.Query.Infrastructure.Cache;
using UserManager.Query.Infrastructure.EventHandling.MassTransit;
using UserManager.Query.Infrastructure.Mapper;
using UserManager.Query.Infrastructure.Mediator;
using UserManager.Query.Infrastructure.QueryCacheManager;

namespace UserManager.Query.Infrastructure;

public static class ServiceRegistrator
{
    public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection, RabbitMQConfiguration rabbitmqConfig)
    {
        serviceCollection.AddSingleton<ICacheManager>(serviceProvider =>
        {
            var redisConfig = serviceProvider.GetRequiredService<IOptions<RedisConfiguration>>().Value;
            var redisCache = new RedisCacheManager(redisConfig);
            redisCache.StartConnection();
            return redisCache;
        });
        
        serviceCollection.AddSingleton<IMediatorManager, MediatrManager>();
        serviceCollection.AddSingleton<IMapperManager, AutoMapperManager>();
        serviceCollection.AddSingleton<IQueryCacheManager, RedisQueryCache>();

        List<Assembly> assemblies = new()
        {
            typeof(ICacheManager).Assembly,
            typeof(RedisCacheManager).Assembly
        };

        serviceCollection.AddMediatR(assemblies.ToArray());
        serviceCollection.AddAutoMapper(assemblies.ToArray());
       
        serviceCollection.AddMassTransit(config =>
        {
            config.AddConsumer<EventConsumerObject>();
            
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitmqConfig.HostName, host =>
                {
                    host.Username(rabbitmqConfig.UserName);
                    host.Password(rabbitmqConfig.Password);
                });
                
                cfg.ReceiveEndpoint(rabbitmqConfig.QueueName, consumer =>
                {
                    consumer.ConfigureConsumer<EventConsumerObject>(context);
                });
            });
        });
    }
}