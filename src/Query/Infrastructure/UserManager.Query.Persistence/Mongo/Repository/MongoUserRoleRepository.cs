using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.Repository;

namespace UserManager.Query.Persistence.Mongo;

public class MongoUserRoleRepository : MongoGenericRepository<UserRole, string>, IUserRoleRepository
{
    private readonly IMongoContext _context;
    
    public MongoUserRoleRepository(IMongoContext context) : base(context)
    {
        _context = context;
    }
}