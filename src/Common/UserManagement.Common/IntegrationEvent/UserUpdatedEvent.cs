namespace UserManagement.Common.IntegrationEvent;

public class UserUpdatedEvent : IIntegrationEvent
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Gender { get; set; }


    public UserUpdatedEvent(string userId, string name, string lastName, int age, int gender)
    {
        this.UserId = userId;
        this.Name = name;
        this.LastName = lastName;
        this.Age = age;
        this.Gender = gender;
    }
}