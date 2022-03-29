namespace UserManagement.Command.Application.DistributedLock;

public interface IDistributedLockManager
{
    public Task<bool> AcquireLockAsync(string lockObjectKey);
    public Task<bool> ReleaseLockAsync(string lockObjectKey);
}