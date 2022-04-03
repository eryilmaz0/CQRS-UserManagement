using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.QueryModel;

public class GetUserWithDetailQuery : Query<GetUserWithDetailQueryResponse>
{
    public string UserId { get; set; }
}