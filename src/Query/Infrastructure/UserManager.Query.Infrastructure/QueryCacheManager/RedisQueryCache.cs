using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.Cache;
using UserManager.Query.Application.QueryCacheManager;

namespace UserManager.Query.Infrastructure.QueryCacheManager;

public class RedisQueryCache : IQueryCacheManager
{
    private readonly ICacheManager _cache;

    public RedisQueryCache(ICacheManager cache)
    {
        _cache = cache;
    }

    public Task CacheUsersAsync(ICollection<User> users)
    {
        throw new NotImplementedException();
    }

    public Task CacheUserRolesAsync(ICollection<UserRole> userRoles)
    {
        throw new NotImplementedException();
    }
}