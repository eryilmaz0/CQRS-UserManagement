namespace UserManagement.Common.IntegrationEvent;

public class RoleAssignedUserEvent : IIntegrationEvent
{
    public string UserId { get; set; }
    public string RoleId { get; set; }

    public RoleAssignedUserEvent(string userId, string roleId)
    {
        this.UserId = userId;
        this.RoleId = roleId;
    }
}
