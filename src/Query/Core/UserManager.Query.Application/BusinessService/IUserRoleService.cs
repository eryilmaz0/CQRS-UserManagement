using MediatR;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.BusinessService;

public interface IUserRoleService : IRequestHandler<ListRolesQuery, ListRolesQueryResponse>
{
    
}