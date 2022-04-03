using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryResponse;

public class GetUserWithRolesQueryResponse : QueryResponse
{
    public GetUserWithRolesViewModel User { get; set; }

    public GetUserWithRolesQueryResponse(bool isSuccess, string resultMessage):base(isSuccess, resultMessage)
    {
        
    }

    public GetUserWithRolesQueryResponse()
    {
        
    }
}