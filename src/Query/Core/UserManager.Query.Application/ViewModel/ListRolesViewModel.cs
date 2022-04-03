namespace UserManager.Query.Application.ViewModel;

public class ListRolesViewModel : ViewModel
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }
}