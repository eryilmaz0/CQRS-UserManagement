using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class ConfirmUserCommand : CommandBase<ConfirmUserResponse>
{
    public string EmailConfirmationToken { get; set; }
    public Guid UserId { get; set; }
}