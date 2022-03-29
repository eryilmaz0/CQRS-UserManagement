namespace UserManagement.Common.IntegrationEvent;

public class UserRoleCreatedEvent : IIntegrationEvent
{
    public string UserRoleId { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }

    public UserRoleCreatedEvent(string userRoleId, string roleName, string roleDescription, bool isDefault)
    {
        this.UserRoleId = userRoleId;
        this.RoleName = roleName;
        this.RoleDescription = roleDescription;
        this.IsDefault = isDefault;
    }
}