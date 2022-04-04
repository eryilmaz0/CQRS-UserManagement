using UserManagement.Common.IntegrationEvent;
using UserManagement.Query.Domain.Entity;
using UserManagement.Query.Domain.Enum;
using UserManager.Query.Application.Repository;

namespace UserManager.Query.Application.BusinessService;

public class EventHandlerService : IEventHandleService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    
    
    public async Task HandleAddressUpdatedEventAsync(AddressUpdatedEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.UserId));

        if (user is null)
            throw new ApplicationException("User Not Found.");

        user.Address.City = @event.City;
        user.Address.Country = @event.Country;
        user.Address.FullAddress = @event.FullAddress;

        await _userRepository.Update(user);
    }
    
    

    public async Task HandleRoleAssignedUserEventAsync(RoleAssignedUserEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.UserId));

        if (user is null)
            throw new ApplicationException("User Not Found.");

        var role = await _userRoleRepository.FindAsync(role => role.Id.Equals(@event.RoleId));

        if (role is null)
            throw new ApplicationException("Role Not Found.");
        
        if(user.UserRoles.Any(roleId => roleId.Equals(@event.RoleId)))
            throw new ApplicationException("User Has Permission Already.");
        
        user.RoleIds.Add(@event.RoleId);
        await _userRepository.Update(user);
    }
    

    public async Task HandleUserConfirmedEventAsync(UserConfirmedEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.ConfirmedUserId));

        if (user is null)
            throw new ApplicationException("User Not Found.");

        user.EmailConfirmed = true;
        await _userRepository.Update(user);
    }
    

    public async Task HandleUserCreatedEventAsync(UserCreatedEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.UserId));

        if (user is not null)
            throw new ApplicationException("There is user that using same user id.");

        user = new()
        {
            Id = @event.UserId,
            Name = @event.Name,
            LastName = @event.LastName,
            Age = @event.Age,
            Gender = (Gender)@event.Gender,
            Email = @event.Email,
            EmailConfirmed = @event.EmailConfirmed,
            Created = @event.Created
        };

        await _userRepository.Insert(user);
    }
    

    public async Task HandleUserRemovedEventAsync(UserRemovedEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.RemovedUserId));

        if (user is null)
            throw new ApplicationException("User Not Found.");

        await _userRepository.Delete(user);
    }
    

    public async Task HandleUserRoleCreatedEventAsync(UserRoleCreatedEvent @event)
    {
        var role = await _userRoleRepository.FindAsync(role => role.Id.Equals(@event.UserRoleId));

        if (role is not null)
            throw new ApplicationException("There is User Role with same Role Id.");

        role = new()
        {
            Id = @event.UserRoleId,
            RoleName = @event.RoleName,
            RoleDescription = @event.RoleDescription,
            IsDefault = @event.IsDefault,
            Created = @event.Created
        };

        await _userRoleRepository.Insert(role);
    }
    
    
    public async Task HandleUserRoleRemovedEventAsync(UserRoleRemovedEvent @event)
    {
        var role = await _userRoleRepository.FindAsync(role => role.Id.Equals(@event.RemovedUserRoleId));

        if (role is null)
            throw new ApplicationException("User Role Not Found.");

        await _userRoleRepository.Delete(role);
    }
    

    public async Task HandleUserRoleUpdatedEventAsync(UserRoleUpdatedEvent @event)
    {
        var role = await _userRoleRepository.FindAsync(role => role.Id.Equals(@event.UserRoleId));

        if (role is not null)
            throw new ApplicationException("User Not Found.");

        role.RoleName = @event.UserRoleName;
        role.RoleDescription = @event.UserRoleDescription;
        role.IsDefault = @event.IsDefault;

        await _userRoleRepository.Update(role);
    }
    

    public async Task HandleUserUpdatedEventAsync(UserUpdatedEvent @event)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(@event.UserId));

        if (user is null)
            throw new ApplicationException("User Not Found.");

        user.Name = @event.Name;
        user.LastName = @event.LastName;
        user.Gender = (Gender)@event.Gender;
        user.Age = @event.Age;
    }
    
}