using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryResponse;

public class GetUserAddressQueryResponse : QueryResponse
{
    public GetUserAddressViewModel Address { get; set; }

    public GetUserAddressQueryResponse(bool isSuccess, string resultMessage):base(isSuccess, resultMessage)
    {
        
    }

    public GetUserAddressQueryResponse()
    {
        
    }
}