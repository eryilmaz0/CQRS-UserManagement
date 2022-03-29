using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity;
using UserManagement.Command.Persistence.Context;

namespace UserManagement.Command.Persistence.Repository.EntityFramework.PostgreSql;

public class AddressRepository : EfBaseRepository<Address>, IAddressRepository
{
    public AddressRepository(CommandAppContext context) : base(context)
    {
    }
}