namespace UserManagement.Command.Domain.Entity.Abstract;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
}