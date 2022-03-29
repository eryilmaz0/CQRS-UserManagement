namespace UserManagement.Common.IntegrationEvent;

public class UserConfirmedEvent : IIntegrationEvent
{
    public string ConfirmedUserId { get; set; }
}