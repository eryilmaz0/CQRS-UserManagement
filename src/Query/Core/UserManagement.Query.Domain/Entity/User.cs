using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using UserManagement.Query.Domain.Enum;

namespace UserManagement.Query.Domain.Entity;

public class User : Entity<string>
{
    public Address Address { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> RoleIds { get; set; }
    
    [BsonIgnore]
    public List<UserRole> UserRoles { get; set; }

    public User():base()
    {
        this.RoleIds = new();
    }
}