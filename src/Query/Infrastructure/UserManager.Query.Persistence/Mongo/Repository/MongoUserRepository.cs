using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Persistence.Mongo;

public class MongoUserRepository : MongoGenericRepository<User, string>, IUserRepository
{
    private readonly IMongoContext _context;
    
    public MongoUserRepository(IMongoContext context) : base(context)
    {
        _context = context;
    }

    
    public Task<GetUserWithRolesViewModel> GetUserWithRolesAsync(string userId)
    {
        throw new NotImplementedException();
    }
}