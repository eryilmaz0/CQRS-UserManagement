using UserManagement.Common.Mapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryCacheManager;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.BusinessService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapperManager _mapper;
    private readonly IQueryCacheManager _queryCacheManager;

    public UserService(IUserRepository userRepository, IMapperManager mapper, IQueryCacheManager queryCacheManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _queryCacheManager = queryCacheManager;
    }

    public async Task<ListUsersQueryResponse> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var usersFromCache = await this._queryCacheManager.ReadListedUsersFromCacheAsync();

        if (usersFromCache is not null)
            return new(true, "Users Listed From Cache.") { Users = usersFromCache };
            
        var users = await _userRepository.GetAllAsync();
        var mapperUsers = _mapper.Map<List<User>, List<ListUsersViewModel>>(users.ToList());

        await this._queryCacheManager.SetCacheListedUsersAsync(mapperUsers);
        return new(true, "Users Listed.") { Users = mapperUsers };
    }
    
    
    public async Task<GetUserWithDetailQueryResponse> Handle(GetUserWithDetailQuery request, CancellationToken cancellationToken)
    {
        var userFromCache = await this._queryCacheManager.ReadDetailedUserFromCacheAsync(request.UserId);

        if (userFromCache is not null)
            return new(true, "User Fetched From Cache.") { User = userFromCache };
        
        var user = await _userRepository.FindAsync(x => x.Id.Equals(request.UserId));

        if (user is null)
            return new(false, "User Not Found.");

        var mappedUser = _mapper.Map<User, GetUserWithDetailViewModel>(user);
        
        await this._queryCacheManager.SetCacheDetailedUserAsync(mappedUser);
        return new(true, "User Fetched.") { User = mappedUser };
    }
    

    public async Task<GetUserWithRolesQueryResponse> Handle(GetUserWithRolesQuery request, CancellationToken cancellationToken)
    {
        var userFromCache = await this._queryCacheManager.ReadUserWithRoleFromCacheAsync(request.UserId);

        if (userFromCache is not null)
            return new(true, "User Fetched From Cache.") { User = userFromCache };
        
        var user = await _userRepository.GetUserWithRolesAsync(request.UserId.ToString());

        if (user is null)
            return new(false, "User Not Found.");

        await this._queryCacheManager.SetCacheUserWithRoleAsync(user);
        return new(true, "User Fetched.") { User = user };
    }
}