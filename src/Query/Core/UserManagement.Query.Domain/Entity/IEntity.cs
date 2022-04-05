using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Query.Domain.Entity;

public interface IEntity<TPrimaryKey>
{
    [BsonId]
    public TPrimaryKey Id { get; set; }
    public DateTime Created { get; set; }
    
}