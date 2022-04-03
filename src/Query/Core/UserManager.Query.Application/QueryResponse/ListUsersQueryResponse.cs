using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.QueryResponse;

public class ListUsersQueryResponse : QueryResponse
{
    public ICollection<ListUsersViewModel> Users { get; set; }

    public ListUsersQueryResponse(bool isSuccess, string resultMessage):base(isSuccess,resultMessage)
    {
        
    }

    public ListUsersQueryResponse()
    {
        
    }
}