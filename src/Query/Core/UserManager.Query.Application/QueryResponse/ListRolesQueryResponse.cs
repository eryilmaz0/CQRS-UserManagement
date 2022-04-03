using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryResponse;

public class ListRolesQueryResponse : QueryResponse
{
    public ICollection<ListRolesViewModel> Roles { get; set; }

    public ListRolesQueryResponse(bool isSuccess, string resultMessage):base(isSuccess, resultMessage)
    {
        
    }

    public ListRolesQueryResponse()
    {
        
    }
}