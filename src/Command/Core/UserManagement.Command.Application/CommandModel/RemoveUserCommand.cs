using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class RemoveUserCommand : CommandBase<RemoveUserResponse>
{
    public Guid UserId { get; set; }
}