namespace UserManagement.Command.Domain.Entity;

public class LoginHistory : Abstract.Entity
{
    public Guid UserId { get; set; }
    public bool IsSuccess { get; set; }

    #region Navigation Props

    public virtual User User { get; set; }
    
    #endregion
}