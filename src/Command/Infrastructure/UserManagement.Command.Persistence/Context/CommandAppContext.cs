using Microsoft.EntityFrameworkCore;
using UserManagement.Command.Domain.Entity;

namespace UserManagement.Command.Persistence.Context;

public class CommandAppContext : DbContext
{
    public CommandAppContext(DbContextOptions<CommandAppContext> opts):base(opts)
    {
        
    }
    

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<LoginHistory> LoginHistories { get; set; }
}