using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryCacheManager;

//Wrapper Interface
public interface IQueryCacheManager
{
    public Task SetCacheListedUsersAsync(ICollection<ListUsersViewModel> users);
    public Task<ICollection<ListUsersViewModel>> ReadListedUsersFromCacheAsync();
    public Task RemoveListedUsersFromCacheAsync();
    public Task SetCacheDetailedUserAsync(GetUserWithDetailViewModel user);
    public Task<GetUserWithDetailViewModel> ReadDetailedUserFromCacheAsync(Guid userId);
    public Task RemoveDetailedUserFromCacheAsync(string userId);
    public Task SetCacheUserWithRoleAsync(GetUserWithRolesViewModel user);
    public Task<GetUserWithRolesViewModel> ReadUserWithRoleFromCacheAsync(Guid userId);
    public Task RemoveUserWithRoleFromCacheAsync(string userId);
    public Task SetCacheListedRolesAsync(ICollection<ListRolesViewModel> roles);
    public Task<ICollection<ListRolesViewModel>> ReadListedRolesFromCacheAsync();
    public Task RemoveListedRolesFromCacheAsync();
}