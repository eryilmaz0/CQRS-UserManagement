using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryCacheManager;

//Wrapper Interface
public interface IQueryCacheManager
{
    public Task SetCacheListedUsersAsync(ICollection<ListUsersViewModel> users);
    public Task<ICollection<ListUsersViewModel>> ReadListedUsersFromCache();
    public Task SetCacheDetailedUserAsync(GetUserWithDetailViewModel user);
    public Task<GetUserWithDetailViewModel> ReadDetailedUserFromCache(Guid userId);
    public Task SetCacheUserWithRoleAsync(GetUserWithRolesViewModel user);
    public Task<GetUserWithRolesViewModel> ReadUserWithRoleFromCache(Guid userId);
    public Task SetCacheListedRolesAsync(ICollection<ListRolesViewModel> roles);
    public Task<ICollection<ListRolesViewModel>> ReadListedRolesFromCacheAsync();
}