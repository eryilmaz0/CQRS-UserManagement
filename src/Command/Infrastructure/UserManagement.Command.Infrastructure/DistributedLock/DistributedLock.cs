using UserManagement.Command.Application.Cache;
using UserManagement.Command.Application.DistributedLock;

namespace UserManagement.Command.Infrastructure.DistributedLock;

public class DistributedLockManager : IDistributedLockManager
{
    private readonly ICacheManager _cache;

    public DistributedLockManager(ICacheManager cache)
    {
        _cache = cache;
    }

    public async Task<bool> AcquireLockAsync(string lockObjectKey)
    {
        if (await this._cache.IsKeyExist(lockObjectKey))
            return false;

        bool acquireLockResult = await this._cache.SetToCache(lockObjectKey, string.Empty);
        return acquireLockResult;
    }
    
    
    public async Task<bool> ReleaseLockAsync(string lockObjectKey)
    {
        if (!await this._cache.IsKeyExist(lockObjectKey))
            return false;

        bool releaseLockResult = await this._cache.RemoveFromCache(lockObjectKey);
        return releaseLockResult;
    }
}