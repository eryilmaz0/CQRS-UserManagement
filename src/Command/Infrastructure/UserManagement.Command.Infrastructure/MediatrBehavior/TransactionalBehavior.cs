using System.Data;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Command.Persistence.Context;
using UserManagement.Common.IntegrationEvent;

namespace UserManagement.Command.Infrastructure.MediatrBehavior;

public class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>  where TRequest : IRequest<TResponse>
{
    private readonly CommandAppContext _context;
    private readonly IIntegrationEventPublisher _eventPublisher;

    public TransactionalBehavior(CommandAppContext context, IIntegrationEventPublisher eventPublisher)
    {
        _context = context;
        _eventPublisher = eventPublisher;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        IDbContextTransaction dbContextTransaction = null;
        if (_context.Database.CurrentTransaction == null)
        {
            dbContextTransaction = await _context.Database.BeginTransactionAsync();
        }
        
        TResponse response = await next();
        await dbContextTransaction.CommitAsync();

        await _eventPublisher.Publish();
        return response;
    }
}