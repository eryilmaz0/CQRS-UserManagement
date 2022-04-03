using UserManagement.Common.IntegrationEvent;

namespace UserManager.Query.Application.BusinessService;

public class EventHandlerService : IEventHandleService
{
    
    public async Task HandleAddressUpdatedEventAsync(AddressUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleAssignedDefaultRoleEventAsync(AssignedDefaultRoleEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleRoleAssignedUserEventAsync(RoleAssignedUserEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserConfirmedEventAsync(UserConfirmedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserCreatedEventAsync(UserCreatedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserRemovedEventAsync(UserRemovedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserRoleCreatedEventAsync(UserRoleCreatedEvent @event)
    {
        throw new NotImplementedException();
    }
    
    
    public async Task HandleUserRoleRemovedEventAsync(UserRoleRemovedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserRoleUpdatedEventAsync(UserRoleUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
    

    public async Task HandleUserUpdatedEventAsync(UserUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
    
}