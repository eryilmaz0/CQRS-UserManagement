namespace UserManagement.Common.Mediator;

public interface IMediatorManager
{
    public Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request);
    
}