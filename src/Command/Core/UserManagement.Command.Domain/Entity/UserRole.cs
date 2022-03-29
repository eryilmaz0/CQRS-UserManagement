namespace UserManagement.Command.Domain.Entity;

public class UserRole : Abstract.Entity
{
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsDefault { get; set; }

    #region Navigation Props

    public virtual ICollection<User> Users { get; set; }
    
    #endregion
}