using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.QueryModel;

public class GetUserWithDetailQuery : Query<GetUserWithDetailQueryResponse>
{
    public Guid UserId { get; set; }
}