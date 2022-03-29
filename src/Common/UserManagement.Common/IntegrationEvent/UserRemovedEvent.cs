namespace UserManagement.Common.IntegrationEvent;

public class UserRemovedEvent : IIntegrationEvent
{
    public string RemovedUserId { get; set; }
}