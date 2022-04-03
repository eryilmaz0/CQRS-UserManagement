using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryResponse;

public class GetUserWithDetailQueryResponse : QueryResponse
{
    public GetUserWithDetailViewModel User { get; set; }

    public GetUserWithDetailQueryResponse(bool isSuccess, string resultMessage):base(isSuccess, resultMessage)
    {
        
    }

    public GetUserWithDetailQueryResponse()
    {
        
    }
}