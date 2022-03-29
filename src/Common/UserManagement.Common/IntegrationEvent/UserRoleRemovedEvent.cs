namespace UserManagement.Common.IntegrationEvent;

public class UserRoleRemovedEvent : IIntegrationEvent
{
    public string RemovedUserRoleId { get; set; }
}