using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Query.Domain.Entity;

public class UserRole : Entity<string>
{
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }
    
    [BsonIgnore]
    public List<User> Users { get; set; }

    public UserRole():base()
    {
        
    }
}