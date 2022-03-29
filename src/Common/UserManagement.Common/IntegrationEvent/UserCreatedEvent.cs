namespace UserManagement.Common.IntegrationEvent;

public class UserCreatedEvent : IIntegrationEvent
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Gender { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public DateTime Created { get; set; }

    public UserCreatedEvent(string userId, string name, string lastName, int age, 
                            int gender, string email, bool emailConfirmed, DateTime created)
    {
        this.UserId = userId;
        this.Name = name;
        this.LastName = lastName;
        this.Age = age;
        this.Gender = gender;
        this.Email = email;
        this.EmailConfirmed = emailConfirmed;
        this.Created = created;
    }

}