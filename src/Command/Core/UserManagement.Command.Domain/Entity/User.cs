
using UserManagement.Command.Domain.Enum;

namespace UserManagement.Command.Domain.Entity;

public class User : Abstract.Entity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; }
    
    #region Navigation Props
    
    public virtual ICollection<LoginHistory> LoginHistories { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual Address Address { get; set; }
    
    #endregion

    public User()
    {
        this.EmailConfirmed = false;
        this.EmailConfirmationToken = Guid.NewGuid().ToString();
        this.UserRoles = new List<UserRole>();
    }
}