using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.QueryModel;

public class GetUserWithRolesQuery : Query<GetUserWithRolesQueryResponse>
{
    public Guid UserId { get; set; }
}