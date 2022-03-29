using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public abstract class CommandBase<TResponse> : ICommand<TResponse> where TResponse : class, ICommandResponse
{
    
}