using Microsoft.EntityFrameworkCore;
using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity;
using UserManagement.Command.Persistence.Context;

namespace UserManagement.Command.Persistence.Repository.EntityFramework.PostgreSql;

public class UserRepository : EfBaseRepository<User>, IUserRepository
{
    private readonly CommandAppContext _context;
    
    public UserRepository(CommandAppContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetUserWithRolesAsync(Guid userId)
    {
        return await _context.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Id.Equals(userId));
    }
}