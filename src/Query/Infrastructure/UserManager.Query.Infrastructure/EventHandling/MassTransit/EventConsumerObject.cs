using MassTransit;
using UserManagement.Common.IntegrationEvent;
using UserManager.Query.Application.BusinessService;

namespace UserManager.Query.Infrastructure.EventHandling.MassTransit;

public class EventConsumerObject : IConsumer<AddressUpdatedEvent>,
                                   IConsumer<AssignedDefaultRoleEvent>,
                                   IConsumer<RoleAssignedUserEvent>,
                                   IConsumer<UserConfirmedEvent>,
                                   IConsumer<UserCreatedEvent>,
                                   IConsumer<UserRemovedEvent>,
                                   IConsumer<UserRoleCreatedEvent>,
                                   IConsumer<UserRoleRemovedEvent>,
                                   IConsumer<UserRoleUpdatedEvent>,
                                   IConsumer<UserUpdatedEvent>

{

    private readonly IEventHandleService _eventHandler;

    public EventConsumerObject(IEventHandleService eventHandler)
    {
        _eventHandler = eventHandler;
    }

    public async Task Consume(ConsumeContext<AddressUpdatedEvent> context)
    {
        await this._eventHandler.HandleAddressUpdatedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<AssignedDefaultRoleEvent> context)
    {
        await this._eventHandler.HandleAssignedDefaultRoleEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<RoleAssignedUserEvent> context)
    {
        await this._eventHandler.HandleRoleAssignedUserEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserConfirmedEvent> context)
    {
        await this._eventHandler.HandleUserConfirmedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        await this._eventHandler.HandleUserCreatedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserRemovedEvent> context)
    {
        await this._eventHandler.HandleUserRemovedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserRoleCreatedEvent> context)
    {
        await this._eventHandler.HandleUserRoleCreatedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserRoleRemovedEvent> context)
    {
        await this._eventHandler.HandleUserRoleRemovedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserRoleUpdatedEvent> context)
    {
        await this._eventHandler.HandleUserRoleUpdatedEventAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        await this._eventHandler.HandleUserUpdatedEventAsync(context.Message);
    }
}