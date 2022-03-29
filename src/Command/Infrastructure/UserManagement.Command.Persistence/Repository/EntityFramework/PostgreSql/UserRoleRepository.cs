using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity;
using UserManagement.Command.Persistence.Context;

namespace UserManagement.Command.Persistence.Repository.EntityFramework.PostgreSql;

public class UserRoleRepository : EfBaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(CommandAppContext context) : base(context)
    {
    }
}