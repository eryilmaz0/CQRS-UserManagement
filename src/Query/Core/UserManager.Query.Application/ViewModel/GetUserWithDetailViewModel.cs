using UserManagement.Query.Domain.Entity;
using UserManagement.Query.Domain.Enum;

namespace UserManager.Query.Application.ViewModel;

public class GetUserWithDetailViewModel : ViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; }
    public List<string> RoleIds { get; set; }
}