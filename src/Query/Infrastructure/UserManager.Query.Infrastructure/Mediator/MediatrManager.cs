using MediatR;
using UserManagement.Common.Mediator;

namespace UserManager.Query.Infrastructure.Mediator;

public class MediatrManager : IMediatorManager
{
    private readonly IMediator _mediator;

    public MediatrManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, string lockObjectKey = null) where TResponse : class, new()
    {
        var result = await _mediator.Send((IRequest<TResponse>)request);
        return result;
    }
}