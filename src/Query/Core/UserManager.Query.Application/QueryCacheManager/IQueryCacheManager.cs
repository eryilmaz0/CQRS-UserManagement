using UserManagement.Query.Domain.Entity;

namespace UserManager.Query.Application.QueryCacheManager;

public interface IQueryCacheManager
{
    public Task CacheUsersAsync(ICollection<User> users);
    public Task CacheUserRolesAsync(ICollection<UserRole> userRoles);
}