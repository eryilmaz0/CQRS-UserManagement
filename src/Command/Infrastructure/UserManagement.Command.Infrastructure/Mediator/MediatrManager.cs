using MediatR;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Application.DistributedLock;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.Infrastructure.Mediator;

public class MediatrManager : IMediatorManager
{
    private readonly IMediator _mediator;
    private readonly IDistributedLockManager _lockManager;

    public MediatrManager(IMediator mediator, IDistributedLockManager lockManager)
    {
        _mediator = mediator;
        _lockManager = lockManager;
    }


    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, string lockObjectKey = null) 
                where TResponse : class, new()
    {
        bool createLock = !string.IsNullOrEmpty(lockObjectKey);

        if (createLock)
        {
            var acquireLock = await _lockManager.AcquireLockAsync(lockObjectKey);

            if (!acquireLock)
            {
                ICommandResponse response = (ICommandResponse)new TResponse();
                response.IsSuccess = false;
                response.ResultMessage = "There are locked objects that this transaction wants to use.";

                return response as TResponse;
            }
        }
            
        var result = await _mediator.Send((IRequest<TResponse>)request);


        if (createLock)
            await _lockManager.ReleaseLockAsync(lockObjectKey);
        
        return result;
    }
}