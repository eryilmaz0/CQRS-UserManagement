using UserManagement.Query.Domain.Enum;

namespace UserManager.Query.Application.ViewModel;

public class GetUserWithRolesViewModel : ViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }   
    public string Password { get; set; }
    public DateTime Created { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public List<string> RoleIds { get; set; }
    public List<RoleViewModel> AssignedRoles { get; set; }
    public AddressviewModel Address { get; set; }
    
}


public class RoleViewModel : ViewModel
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }
    public DateTime Created { get; set; }
}


public class AddressviewModel : ViewModel
{
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }
}