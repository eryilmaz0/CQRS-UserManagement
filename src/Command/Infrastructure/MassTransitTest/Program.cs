// See https://aka.ms/new-console-template for more information

using MassTransit;
using MassTransitTest;

var bus = BusConfigurator.ConfigureBus(factory =>
{
    factory.ReceiveEndpoint("cqrs-queue", endPoint =>
    {
        endPoint.Consumer<TestConsumer>();
    });
});

await bus.StartAsync();
Console.WriteLine("Hello, World!");
await Task.Run(() => Console.ReadLine());
await bus.StopAsync();