using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class UpdateUserRoleCommand : CommandBase<UpdateUserRoleResponse>
{
    public Guid UserRoleId { get; set; }
    public string UserRoleName { get; set; }
    public string UserRoleDescription { get; set; }
    public bool IsDefault { get; set; }
}