namespace UserManager.Query.Application.ViewModel;

public class GetUserWithRolesViewModel : ViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<RoleViewModel> AssignedRoles { get; set; }       
    
    
}


public class RoleViewModel
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }
}