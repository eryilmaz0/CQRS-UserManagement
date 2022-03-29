using MassTransit;
using UserManagement.Command.Application.Cache;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Common.IntegrationEvent;

namespace UserManagement.Command.Infrastructure.IntegrationEventPublisher;

public class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;
    private List<IIntegrationEvent> events;


    public IntegrationEventPublisher( IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        events = new();
    }

    public async Task RegisterEvent(IIntegrationEvent @event)
    {
        this.events.Add(@event);
    }

    public async Task Publish()
    {
        List<Task> publishTasks = new();
        foreach (IIntegrationEvent @event in this.events)
        {
            Task publishTask = _publishEndpoint.Publish(@event, @event.GetType());
            publishTasks.Add(publishTask);
        }

        await Task.WhenAll(publishTasks);
    }
}