using UserManagement.Command.Application.CommandResponse;
using UserManagement.Command.Application.Dto;
using UserManagement.Command.Domain.Enum;

namespace UserManagement.Command.Application.CommandModel;

public class CreateUserCommand : CommandBase<CreateUserResponse>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AddressDto Address { get; set; }
}