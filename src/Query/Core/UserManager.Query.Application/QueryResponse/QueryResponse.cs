namespace UserManager.Query.Application.QueryResponse;

public class QueryResponse : IQueryResponse
{
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }

    
    public QueryResponse(bool isSuccess, string resultMessage)
    {
        this.IsSuccess = isSuccess;
        this.ResultMessage = resultMessage;
    }

    public QueryResponse()
    {
        
    }
}