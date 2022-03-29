using UserManagement.Common.IntegrationEvent;

namespace UserManagement.Command.Application.IntegrationEventPublisher;

public interface IIntegrationEventPublisher
{
    public Task RegisterEvent(IIntegrationEvent @event);
    public Task Publish();
}