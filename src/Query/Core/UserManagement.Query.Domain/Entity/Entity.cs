using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Query.Domain.Entity;

public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
{
    [BsonId]
    public TPrimaryKey Id { get; set; }
    public DateTime Created { get; set; }

    public Entity()
    {
        this.Created = DateTime.Now;
    }
}