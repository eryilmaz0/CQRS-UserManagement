using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class RemoveUserRoleCommandValidator : AbstractValidator<RemoveUserRoleCommand>
{
    public RemoveUserRoleCommandValidator()
    {
        RuleFor(property => property.UserRoleId).NotEmpty().WithMessage("UserRoleId Can Not be Null or Empty.");
    }
}