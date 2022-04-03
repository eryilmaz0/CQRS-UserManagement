namespace UserManager.Query.Application.Configuration;

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}