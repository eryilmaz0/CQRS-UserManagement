namespace UserManager.Query.Application.QueryResponse;

public interface IQueryResponse
{
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }
}