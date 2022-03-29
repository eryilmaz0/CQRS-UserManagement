using MediatR;
using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public interface ICommand<TResponse> : IRequest<TResponse> where TResponse : class, ICommandResponse
{
    
}