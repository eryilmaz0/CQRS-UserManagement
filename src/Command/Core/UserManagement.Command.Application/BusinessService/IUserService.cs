using MediatR;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.BusinessService;

public interface IUserService : IRequestHandler<CreateUserCommand, CreateUserResponse>,
                                IRequestHandler<ConfirmUserCommand, ConfirmUserResponse>,
                                IRequestHandler<RemoveUserCommand, RemoveUserResponse>,
                                IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    
}