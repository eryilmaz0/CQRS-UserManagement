using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class AssignRoleToUserCommandValidator : AbstractValidator<AssignRoleToUserCommand>
{
    public AssignRoleToUserCommandValidator()
    {
        RuleFor(property => property.UserId).NotEmpty().WithMessage("UserId Can Not be Null or Empty.");
        RuleFor(property => property.UserRoleId).NotEmpty().WithMessage("UserRoleId Can Not be Null or Empty.");
    }
}