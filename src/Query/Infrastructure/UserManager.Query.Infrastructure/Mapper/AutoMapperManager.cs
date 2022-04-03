using AutoMapper;
using UserManagement.Common.Mapper;

namespace UserManager.Query.Infrastructure.Mapper;

public class AutoMapperManager : IMapperManager
{
    private readonly IMapper _mapper;

    public AutoMapperManager(IMapper mapper)
    {
        this._mapper = mapper;
    }

    public TMappedData Map<TData, TMappedData>(TData data)
    {
        return _mapper.Map<TMappedData>(data);
    }
}