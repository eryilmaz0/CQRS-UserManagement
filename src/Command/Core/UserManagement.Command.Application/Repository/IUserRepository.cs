using UserManagement.Command.Domain.Entity;

namespace UserManagement.Command.Application.Repository;

public interface IUserRepository : IRepository<User>
{
    public Task<User> GetUserWithRolesAsync(Guid userId);
}