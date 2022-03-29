namespace UserManagement.Common.IntegrationEvent;

public class AssignedDefaultRoleEvent : IIntegrationEvent
{
    public string UserId { get; set; }
    public string UserRoleId { get; set; }

    public AssignedDefaultRoleEvent(string userId, string userRoleId)
    {
        this.UserId = userId;
        this.UserRoleId = userRoleId;
    }
}