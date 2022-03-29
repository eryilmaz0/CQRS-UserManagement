using MediatR;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;


namespace UserManagement.Command.Application.BusinessService;

public interface IUserRoleService : IRequestHandler<AssignRoleToUserCommand, AssignRoleToUserResponse>,
                                    IRequestHandler<CreateUserRoleCommand, CreateUserRoleResponse>,
                                    IRequestHandler<RemoveUserRoleCommand, RemoveUserRoleResponse>,
                                    IRequestHandler<UpdateUserRoleCommand, UpdateUserRoleResponse>
                                    

{
    
}