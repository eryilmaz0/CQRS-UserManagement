using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Application.DistributedLock;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity;
using UserManagement.Common.IntegrationEvent;
using UserManagement.Common.Mapper;

namespace UserManagement.Command.Application.BusinessService;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapperManager _mapper;
    private readonly IIntegrationEventPublisher _eventPublisher;
    private readonly IDistributedLockManager _lockManager;

    public UserRoleService(IUserRoleRepository userRoleRepository,IUserRepository userRepository,IMapperManager mapper,
                            IIntegrationEventPublisher eventPublisher, IDistributedLockManager lockManager)
    {
        _userRoleRepository = userRoleRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _eventPublisher = eventPublisher;
        _lockManager = lockManager;
    }

    
    public async Task<AssignRoleToUserResponse> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithRolesAsync(request.UserId);

        if (user is null)
            return new() { IsSuccess = false, ResultMessage = "User Not Found" };

        var userRole = await _userRoleRepository.FindAsync(role => role.Id.Equals(request.UserRoleId));

        if (userRole is null)
            return new() { IsSuccess = false, ResultMessage = "UserRole Not Found." };

        if (user.UserRoles.Any(role => role.Id.Equals(request.UserRoleId)))
            return new() { IsSuccess = false, ResultMessage = "User Already Has This Role." };
        
        user.UserRoles.Add(userRole);
        var result = await _userRepository.UpdateAsync(user);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "Role Not Assigned to User." };

        await _lockManager.ReleaseLockAsync($"user_{request.UserId.ToString()}");
        
        _eventPublisher.RegisterEvent(new RoleAssignedUserEvent(user.Id.ToString(), userRole.Id.ToString()));
        return new() { IsSuccess = true, ResultMessage = "Role Assigned to User Successfully." };
    }
    

    public async Task<CreateUserRoleResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var newUserRole = _mapper.Map<CreateUserRoleCommand, UserRole>(request);
        bool result = await _userRoleRepository.InsertAsync(newUserRole);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "UserRole Not Inserted" };

        _eventPublisher.RegisterEvent(new UserRoleCreatedEvent(newUserRole.Id.ToString(), newUserRole.RoleName, newUserRole.RoleDescription, newUserRole.IsDefault, newUserRole.Created));
        return new() { IsSuccess = true, ResultMessage = "User Role Inserted" };
    }

    
    public async Task<RemoveUserRoleResponse> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.FindAsync(role => role.Id.Equals(request.UserRoleId));

        if (userRole is null)
            return new() { IsSuccess = false, ResultMessage = "User Role Not Found" };

        bool result = await _userRoleRepository.DeleteAsync(userRole);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "User Role Not Removed" };

        await _lockManager.ReleaseLockAsync($"userrole_{request.UserRoleId.ToString()}");
        
        _eventPublisher.RegisterEvent(new UserRoleRemovedEvent(){RemovedUserRoleId = request.UserRoleId.ToString()});
        return new() { IsSuccess = true, ResultMessage = "User Role Removed Successfully." };
    }

    
    public async Task<UpdateUserRoleResponse> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.FindAsync(role => role.Id.Equals(request.UserRoleId));

        if (userRole is null)
            return new() { IsSuccess = false, ResultMessage = "User Role Not Found" };

        userRole.RoleName = request.UserRoleName;
        userRole.RoleDescription = request.UserRoleDescription;
        userRole.IsDefault = request.IsDefault;

        bool result = await _userRoleRepository.UpdateAsync(userRole);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "User Role Not Updated" };

        await _lockManager.ReleaseLockAsync($"userrole_{request.UserRoleId.ToString()}");
        
        _eventPublisher.RegisterEvent(new UserRoleUpdatedEvent(userRole.Id.ToString(), userRole.RoleName, userRole.RoleDescription, userRole.IsDefault));
        return new() { IsSuccess = true, ResultMessage = "User Role Updated Successfully." };
    }
    
}