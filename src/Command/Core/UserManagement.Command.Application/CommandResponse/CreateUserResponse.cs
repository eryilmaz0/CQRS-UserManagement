namespace UserManagement.Command.Application.CommandResponse;

public class CreateUserResponse : CommandResponse
{
    public Guid CreatedUserId { get; set; }
}