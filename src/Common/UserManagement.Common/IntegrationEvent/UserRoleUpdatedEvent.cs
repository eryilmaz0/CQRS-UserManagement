namespace UserManagement.Common.IntegrationEvent;

public class UserRoleUpdatedEvent : IIntegrationEvent
{
    public string UserRoleId { get; set; }
    public string UserRoleName { get; set; }
    public string UserRoleDescription { get; set; }
    public bool IsDefault { get; set; }

    public UserRoleUpdatedEvent(string userRoleId, string userRoleName, string userRoleDescription, bool isDefault)
    {
        this.UserRoleId = userRoleId;
        this.UserRoleName = userRoleName;
        this.UserRoleDescription = userRoleDescription;
        this.IsDefault = isDefault;
    }
}