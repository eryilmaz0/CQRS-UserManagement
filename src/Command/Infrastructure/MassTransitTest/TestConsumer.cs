using MassTransit;
using UserManagement.Common.IntegrationEvent;

namespace MassTransitTest;

public class TestConsumer : IConsumer<UserCreatedEvent>,
                            IConsumer<AddressUpdatedEvent>,
                            IConsumer<RoleAssignedUserEvent>,
                            IConsumer<UserConfirmedEvent>,
                            IConsumer<UserRemovedEvent>,
                            IConsumer<UserRoleCreatedEvent>,
                            IConsumer<UserRoleRemovedEvent>,
                            IConsumer<UserUpdatedEvent>,
                            IConsumer<UserRoleUpdatedEvent>
{
    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        Console.Write("das");
        return Task.CompletedTask;
    }

    
    public Task Consume(ConsumeContext<AddressUpdatedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<RoleAssignedUserEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserConfirmedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserRemovedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserRoleCreatedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserRoleRemovedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<UserRoleUpdatedEvent> context)
    {
        throw new NotImplementedException();
    }
}