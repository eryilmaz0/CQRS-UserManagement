namespace UserManagement.Common.IntegrationEvent;

public class AddressUpdatedEvent : IIntegrationEvent
{
    public string UserId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }

    public AddressUpdatedEvent(string userId, string city, string country, string fullAddress)
    {
        this.UserId = userId;
        this.City = city;
        this.Country = country;
        this.FullAddress = fullAddress;
    }
}