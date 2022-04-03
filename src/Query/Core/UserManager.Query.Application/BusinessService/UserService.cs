using UserManagement.Common.Mapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.BusinessService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapperManager _mapper;

    public UserService(IUserRepository userRepository, IMapperManager mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ListUsersQueryResponse> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        var mapperUsers = _mapper.Map<List<User>, List<ListUsersViewModel>>(users.ToList());

        return new(true, "Users Listed.") { Users = mapperUsers };
    }
    
    
    public async Task<GetUserWithDetailQueryResponse> Handle(GetUserWithDetailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id.Equals(request.UserId));

        if (user is null)
            return new(false, "User Not Found.");

        var mappedUser = _mapper.Map<User, GetUserWithDetailViewModel>(user);

        return new(true, "User Fetched.") { User = mappedUser };
    }
    

    public async Task<GetUserWithRolesQueryResponse> Handle(GetUserWithRolesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithRolesAsync(request.UserId);

        if (user is null)
            return new(false, "User Not Found.");
        
        return new(true, "User Fetched.") { User = user };
    }
}