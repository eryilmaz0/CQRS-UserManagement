using UserManagement.Common.IntegrationEvent;

namespace UserManager.Query.Application.BusinessService;

public interface IEventHandleService
{
    public Task HandleAddressUpdatedEventAsync(AddressUpdatedEvent @event);
    public Task HandleAssignedDefaultRoleEventAsync(AssignedDefaultRoleEvent @event);
    public Task HandleRoleAssignedUserEventAsync(RoleAssignedUserEvent @event);
    public Task HandleUserConfirmedEventAsync(UserConfirmedEvent @event);
    public Task HandleUserCreatedEventAsync(UserCreatedEvent @event);
    public Task HandleUserRemovedEventAsync(UserRemovedEvent @event);
    public Task HandleUserRoleCreatedEventAsync(UserRoleCreatedEvent @event);
    public Task HandleUserRoleRemovedEventAsync(UserRoleRemovedEvent @event);
    public Task HandleUserRoleUpdatedEventAsync(UserRoleUpdatedEvent @event);
    public Task HandleUserUpdatedEventAsync(UserUpdatedEvent @event);
}