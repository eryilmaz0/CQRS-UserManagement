using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManager.Query.Application.Configuration;

namespace UserManager.Query.Persistence.Mongo;

public class MongoContext : IMongoContext
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _mongoDb;
    private readonly MongoDbConfiguration _config;

    public MongoContext(IOptions<MongoDbConfiguration> config)
    {
        _config = config.Value;
        
        string formattedConnectionString = _config.ConnectionString;
        _client = new MongoClient(_config.ConnectionString);
        _mongoDb = _client.GetDatabase(_config.Database);
    }

    
    public IMongoCollection<TCollection> GetCollection<TCollection>(string collectionName) where TCollection : class
    {
        return _mongoDb.GetCollection<TCollection>(collectionName);
    }
}