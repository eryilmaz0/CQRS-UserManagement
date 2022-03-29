using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class AssignRoleToUserCommand : CommandBase<AssignRoleToUserResponse>
{
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }
}