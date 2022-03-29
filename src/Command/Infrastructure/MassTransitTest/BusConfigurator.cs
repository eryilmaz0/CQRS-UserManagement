using MassTransit;
using MassTransit.RabbitMqTransport;

namespace MassTransitTest;

public static class BusConfigurator
{

    public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
    {
        return Bus.Factory.CreateUsingRabbitMq(factory =>
        {
            factory.Host("rabbitmq://localhost/CQRSUserManagement", configurator =>
            {
                configurator.Username("guest");
                configurator.Password("123456");
            });

            registrationAction?.Invoke(factory);
        });
    }
    
    /*public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
    {
        return Bus.Factory.CreateUsingRabbitMq(factory =>
        {
            factory.Host("rabbitmq://localhost/CQRSUserManagement", configurator =>
            {
                configurator.Username("guest");
                configurator.Password("guest");
            });

            registrationAction?.Invoke(factory);
        });
    }*/
}