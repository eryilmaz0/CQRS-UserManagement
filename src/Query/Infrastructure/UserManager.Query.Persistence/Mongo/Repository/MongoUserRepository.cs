using MongoDB.Driver;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Persistence.Mongo;

public class MongoUserRepository : MongoGenericRepository<User, string>, IUserRepository
{
    private readonly IMongoContext _context;
    private readonly IMongoCollection<User> _collection;

    public MongoUserRepository(IMongoContext context) : base(context)
    {
        _context = context;
        _collection = _context.GetCollection<User>("User");
    }

    
    public async Task<GetUserWithRolesViewModel> GetUserWithRolesAsync(string userId)
    {
        var result = _collection.Aggregate<User>().Lookup<User, UserRole, GetUserWithRolesViewModel>(_context.GetCollection<UserRole>("UserRole"),
            fromType => fromType.RoleIds, targetType => targetType.Id, outputType => outputType.AssignedRoles).FirstOrDefaultAsync();

        return await result;
    }
}