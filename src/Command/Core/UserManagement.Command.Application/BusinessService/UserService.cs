using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Application.DistributedLock;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity;
using UserManagement.Common.IntegrationEvent;
using UserManagement.Common.Mapper;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.Application.BusinessService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapperManager _mapper;
    private readonly IMediatorManager _mediator;
    private readonly IIntegrationEventPublisher _eventPublisher;
    private readonly IDistributedLockManager _lockManager;

    public UserService(IUserRepository userRepository,IMapperManager mapper, IMediatorManager mediator,IIntegrationEventPublisher eventPublisher,
                        IDistributedLockManager lockManager, IUserRoleRepository userRoleRepository)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _mediator = mediator;
        _eventPublisher = eventPublisher;
        _lockManager = lockManager;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<CreateUserCommand, User>(request);
        var defaultRole = await _userRoleRepository.FindAsync(x => x.IsDefault);
        user.UserRoles.Add(defaultRole);

        var result = await _userRepository.InsertAsync(user);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "User Not Created" };

        _eventPublisher.RegisterEvent(new UserCreatedEvent(user.Id.ToString(), user.Name, user.LastName, user.Age, 
                                                            (int)user.Gender, user.Email, user.EmailConfirmed, user.Created));

        return new() { IsSuccess = true, ResultMessage = "User Created", CreatedUserId = user.Id };
    }

    
    public async Task<ConfirmUserResponse> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(request.UserId));

        if (user is null)
            return new() { IsSuccess = false, ResultMessage = "User not Found" };
        
        if(!user.EmailConfirmationToken.Equals(request.EmailConfirmationToken))
            return new() { IsSuccess = false, ResultMessage = "Email Confirmation Tokens Does Not Match" };

        user.EmailConfirmed = true;
        bool updateResult = await _userRepository.UpdateAsync(user);
        
        if(!updateResult)
            return new() { IsSuccess = false, ResultMessage = "User not Updated" };

        await _lockManager.ReleaseLockAsync($"user_{request.UserId.ToString()}");
        
        _eventPublisher.RegisterEvent(new UserConfirmedEvent() { ConfirmedUserId = user.Id.ToString()});
        return new() { IsSuccess = true, ResultMessage = "User Confirmed Successfully."};
    }
    

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(request.UserId));

        if (user is null)
            return new() { IsSuccess = false, ResultMessage = "User not Found" };

        user.Name = request.Name;
        user.LastName = request.LastName;
        user.Age = request.Age;
        user.Gender = request.Gender;

        var result = await _userRepository.UpdateAsync(user);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "User Not Updated." };

        await _lockManager.ReleaseLockAsync($"user_{request.UserId.ToString()}");
        
        _eventPublisher.RegisterEvent(new UserUpdatedEvent(user.Id.ToString(), user.Name, user.LastName, user.Age, (int)user.Gender));
        return new() { IsSuccess = true, ResultMessage = "User Updated Successfully." };
    }
    
    
    public async Task<RemoveUserResponse> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(user => user.Id.Equals(request.UserId));

        if (user is null)
            return new() { IsSuccess = false, ResultMessage = "User not Found" };

        bool result = await _userRepository.DeleteAsync(user);

        if (!result)
            return new() { IsSuccess = true, ResultMessage = "User Not Deleted" };

        _eventPublisher.RegisterEvent(new UserRemovedEvent() { RemovedUserId = request.UserId.ToString() });
        return new() { IsSuccess = true, ResultMessage = "User Deleted Successfully." };
    }
    
}