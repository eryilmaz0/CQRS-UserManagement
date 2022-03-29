using System.Reflection;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserManagement.Command.API.ConfigurationModel;
using UserManagement.Command.Application.Cache;
using UserManagement.Command.Application.DistributedLock;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Command.Infrastructure.Cache;
using UserManagement.Command.Infrastructure.DistributedLock;
using UserManagement.Command.Infrastructure.Mapper;
using UserManagement.Command.Infrastructure.Mediator;
using UserManagement.Command.Infrastructure.MediatrBehavior;
using UserManagement.Common.Mapper;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.Infrastructure;

public static class ServiceRegistrator
{
    public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection, RabbitMQConfiguration rabbitmqConfig)
    {
        serviceCollection.AddSingleton<IDistributedLockManager, DistributedLockManager>();
        serviceCollection.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher.IntegrationEventPublisher>();
        serviceCollection.AddSingleton<IMapperManager, AutoMapperManager>();
        serviceCollection.AddScoped<IMediatorManager, MediatrManager>();
        serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalBehavior<,>));

        serviceCollection.AddSingleton<ICacheManager>(serviceProvider =>
        {
            var redisConfig = serviceProvider.GetRequiredService<IOptions<RedisConfiguration>>().Value;
            var redisCache = new RedisCache(redisConfig);
            redisCache.StartConnection();
            return redisCache;
        });

        serviceCollection.AddMassTransit(x=>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitmqConfig.HostName, host =>
                {
                    host.Username(rabbitmqConfig.UserName);
                    host.Password(rabbitmqConfig.Password);
                });
            });
        });
    }
}