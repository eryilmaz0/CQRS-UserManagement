using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Domain.Enum;

namespace UserManagement.Command.Application.CommandModel;

public class UpdateUserCommand : CommandBase<UpdateUserResponse>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
}