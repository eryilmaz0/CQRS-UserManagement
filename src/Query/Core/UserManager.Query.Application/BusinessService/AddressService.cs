using UserManagement.Common.Mapper;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;
using UserManager.Query.Application.Repository;
using UserManager.Query.Application.ViewModel;

namespace UserManager.Query.Application.BusinessService;

public class AddressService : IAddressService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapperManager _mapper;

    public AddressService(IUserRepository userRepository, IMapperManager mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserAddressQueryResponse> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id.Equals(request.UserId));

        if (user is null)
            return new(false, "User Not Found.");
        
        var address = _mapper.Map<User, GetUserAddressViewModel>(user);
        return new(true, "Address Fetched.") { Address = address};
    }
}