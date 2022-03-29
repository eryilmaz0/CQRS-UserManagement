using AutoMapper;
using UserManagement.Common.Mapper;

namespace UserManagement.Command.Infrastructure.Mapper;

public class AutoMapperManager : IMapperManager
{
    private readonly IMapper _mapper;

    public AutoMapperManager(IMapper mapper)
    {
        _mapper = mapper;
    }

    //Will Use AutoMapper   
    public TMappedData Map<TData, TMappedData>(TData data)
    {
        return _mapper.Map<TMappedData>(data);
    }
}