namespace UserManagement.Command.Domain.Entity;

public class Address : Abstract.Entity
{
    public Guid UserId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }

    #region Navigation Props
    
    public virtual User User { get; set; }
    
    #endregion
}