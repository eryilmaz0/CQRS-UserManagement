using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.Repository;

public interface IUserRepository : IRepository<User, string>
{
    public Task<GetUserWithRolesViewModel> GetUserWithRolesAsync(string userId);
}