using UserManagement.Common.Mapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.BusinessService;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapperManager _mapper;

    public UserRoleService(IUserRoleRepository userRoleRepository, IMapperManager mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<ListRolesQueryResponse> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _userRoleRepository.GetAllAsync();
        var mappedRoles = _mapper.Map<List<UserRole>, List<ListRolesViewModel>>(userRoles.ToList());
        return new(true, "Roles Listed.") { Roles = mappedRoles };
    }
}