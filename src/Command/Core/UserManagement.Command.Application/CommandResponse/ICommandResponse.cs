namespace UserManagement.Command.Application.CommandResponse;

public interface ICommandResponse
{
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }
}