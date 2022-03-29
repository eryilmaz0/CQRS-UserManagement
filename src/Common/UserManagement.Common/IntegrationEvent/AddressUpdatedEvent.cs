namespace UserManagement.Common.IntegrationEvent;

public class AddressUpdatedEvent : IIntegrationEvent
{
    public string AddressId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }

    public AddressUpdatedEvent(string addressId, string city, string country, string fullAddress)
    {
        this.AddressId = addressId;
        this.City = city;
        this.Country = country;
        this.FullAddress = fullAddress;
    }
}