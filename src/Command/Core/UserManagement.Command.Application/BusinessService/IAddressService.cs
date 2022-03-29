using MediatR;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;

namespace UserManagement.Command.Application.BusinessService;

public interface IAddressService : IRequestHandler<UpdateAddressCommand, UpdateAddressResponse>
{
    
}