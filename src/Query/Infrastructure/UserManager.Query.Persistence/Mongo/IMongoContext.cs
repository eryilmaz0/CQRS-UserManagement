using MongoDB.Driver;
using UserManager.Query.Application.Configuration;

namespace UserManager.Query.Persistence.Mongo;

public interface IMongoContext
{
    public IMongoCollection<TCollection> GetCollection<TCollection>() where TCollection : class;
}