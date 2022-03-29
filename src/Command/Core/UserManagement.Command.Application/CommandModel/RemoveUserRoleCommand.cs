using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class RemoveUserRoleCommand : CommandBase<RemoveUserRoleResponse>
{
    public Guid UserRoleId { get; set; }
}