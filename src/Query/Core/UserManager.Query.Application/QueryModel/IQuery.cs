using MediatR;

namespace UserManager.Query.Application.QueryModel;

public interface IQuery<TResponse> : IRequest<TResponse>
{
        
}