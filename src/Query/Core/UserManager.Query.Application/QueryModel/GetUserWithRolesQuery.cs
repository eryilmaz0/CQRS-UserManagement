using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.QueryModel;

public class GetUserWithRolesQuery : Query<GetUserWithRolesQueryResponse>
{
    public string UserId { get; set; }
}