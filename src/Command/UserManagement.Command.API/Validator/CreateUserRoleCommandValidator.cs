using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(property => property.RoleName).NotEmpty().WithMessage("RoleName Can Not be Null or Empty.");
        RuleFor(property => property.RoleDescription).NotEmpty().WithMessage("RoleDescription Can Not be Null or Empty.");
    }
}