using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.CommandModel;

public class UpdateAddressCommand : CommandBase<UpdateAddressResponse>
{
    public Guid AddressId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }
    
}