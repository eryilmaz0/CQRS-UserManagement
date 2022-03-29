namespace UserManagement.Command.Application.CommandResponse;

public abstract class CommandResponse : ICommandResponse
{
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }
}