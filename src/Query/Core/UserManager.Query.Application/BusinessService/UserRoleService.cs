using UserManagement.Common.Mapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryCacheManager;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.BusinessService;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapperManager _mapper;
    private readonly IQueryCacheManager _queryCacheManager;

    public UserRoleService(IUserRoleRepository userRoleRepository, IMapperManager mapper, IQueryCacheManager queryCacheManager)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _queryCacheManager = queryCacheManager;
    }

    public async Task<ListRolesQueryResponse> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        var listedRoles = await this._queryCacheManager.ReadListedRolesFromCacheAsync();

        if (listedRoles is not null)
            return new(true, "Roles Listed From Cache.") { Roles = listedRoles };
        
        var userRoles = await _userRoleRepository.GetAllAsync();
        var mappedRoles = _mapper.Map<List<UserRole>, List<ListRolesViewModel>>(userRoles.ToList());

        await this._queryCacheManager.SetCacheListedRolesAsync(mappedRoles);
        return new(true, "Roles Listed.") { Roles = mappedRoles };
    }
}