using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.Cache;
using UserManager.Query.Application.QueryCacheManager;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Infrastructure.QueryCacheManager;

public class QueryCacheManager : IQueryCacheManager
{
    private readonly ICacheManager _cache;

    public QueryCacheManager(ICacheManager cache)
    {
        _cache = cache;
    }


    public async Task SetCacheListedUsersAsync(ICollection<ListUsersViewModel> users) =>  await this._cache.SetToCacheAsync("ListedUsers", users.ToList());
    public async Task RemoveListedUsersFromCacheAsync() => await this._cache.RemoveFromCacheAsync("ListedUsers");
    
    public async Task SetCacheDetailedUserAsync(GetUserWithDetailViewModel user) => await this._cache.SetToCacheAsync($"DetailedUser_{user.Id}", user);
    public async Task RemoveDetailedUserFromCacheAsync(string userId) => await this._cache.RemoveFromCacheAsync($"DetailedUser_{userId}");

    public async Task SetCacheUserWithRoleAsync(GetUserWithRolesViewModel user) => await this._cache.SetToCacheAsync($"UserWithRole_{user.Id}", user);
    public async Task RemoveUserWithRoleFromCacheAsync(string userId) => await this._cache.RemoveFromCacheAsync($"UserWithRole_{userId}");
    
    public async Task SetCacheListedRolesAsync(ICollection<ListRolesViewModel> roles) => await this._cache.SetToCacheAsync("ListedRoles", roles.ToList());
    public async Task RemoveListedRolesFromCacheAsync() => await this._cache.RemoveFromCacheAsync("ListedRoles");
   
    public async Task<ICollection<ListUsersViewModel>> ReadListedUsersFromCacheAsync()
    {
        ICollection<ListUsersViewModel> listedUsers = null;

        if (await this._cache.IsKeyExistAsync("ListedUsers"))
        {
            listedUsers = await this._cache.ReadFromCacheAsync<List<ListUsersViewModel>>("ListedUsers");
        }

        return listedUsers;
    }

    public async Task<GetUserWithDetailViewModel> ReadDetailedUserFromCacheAsync(Guid userId)
    {
        GetUserWithDetailViewModel detailedUser = null;

        if (await this._cache.IsKeyExistAsync($"DetailedUser_{userId.ToString()}"))
        {
            detailedUser = await this._cache.ReadFromCacheAsync<GetUserWithDetailViewModel>($"DetailedUser_{userId.ToString()}");
        }
        return detailedUser;
    }
    
    public async Task<GetUserWithRolesViewModel> ReadUserWithRoleFromCacheAsync(Guid userId)
    {
        GetUserWithRolesViewModel userWithRole = null;

        if (await this._cache.IsKeyExistAsync($"UserWithRole_{userId.ToString()}"))
        {
            userWithRole = await this._cache.ReadFromCacheAsync<GetUserWithRolesViewModel>($"UserWithRole_{userId.ToString()}");
        }

        return userWithRole;
    }

    public async Task<ICollection<ListRolesViewModel>> ReadListedRolesFromCacheAsync()
    {
        List<ListRolesViewModel> listedRoles = null;

        if (await this._cache.IsKeyExistAsync("ListedRoles"))
        {
            listedRoles = await this._cache.ReadFromCacheAsync<List<ListRolesViewModel>>("ListedRoles");
        }

        return listedRoles;
    }
}