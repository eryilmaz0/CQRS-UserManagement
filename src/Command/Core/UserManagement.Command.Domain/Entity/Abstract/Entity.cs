namespace UserManagement.Command.Domain.Entity.Abstract;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    

    public Entity()
    {
        this.Created = DateTime.UtcNow;
    }
}