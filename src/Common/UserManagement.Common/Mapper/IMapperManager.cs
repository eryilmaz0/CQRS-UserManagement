namespace UserManagement.Common.Mapper;

public interface IMapperManager
{
    public TMappedData Map<TData, TMappedData>(TData data);
}