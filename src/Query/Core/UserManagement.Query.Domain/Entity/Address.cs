namespace UserManagement.Query.Domain.Entity;

public class Address : Entity<string>
{
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }
}