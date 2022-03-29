using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Application.IntegrationEventPublisher;
using UserManagement.Command.Application.Repository;
using UserManagement.Common.IntegrationEvent;

namespace UserManagement.Command.Application.BusinessService;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IIntegrationEventPublisher _eventPublisher;

    public AddressService(IAddressRepository addressRepository, IIntegrationEventPublisher eventPublisher)
    {
        _addressRepository = addressRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<UpdateAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.FindAsync(address => address.Id.Equals(request.AddressId));

        if (address is null)
            return new() { IsSuccess = false, ResultMessage = "Address Not Found" };

        address.City = request.City;
        address.Country = request.Country;
        address.FullAddress = request.FullAddress;

        bool result = await _addressRepository.UpdateAsync(address);

        if (!result)
            return new() { IsSuccess = false, ResultMessage = "Address Not Updated" };

        _eventPublisher.RegisterEvent(new AddressUpdatedEvent(address.Id.ToString(), address.City, address.Country, address.FullAddress));
        return new() { IsSuccess = true, ResultMessage = "Address Updated Successfully." };
    }
}