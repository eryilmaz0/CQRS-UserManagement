using UserManager.Query.Application.QueryResponse;

namespace UserManager.Query.Application.QueryModel;

public class GetUserAddressQuery : Query<GetUserAddressQueryResponse>
{
    public string UserId { get; set; }
}