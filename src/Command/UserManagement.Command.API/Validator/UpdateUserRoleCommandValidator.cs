using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
{
    public UpdateUserRoleCommandValidator()
    {
        RuleFor(property => property.UserRoleId).NotEmpty().WithMessage("UserRoleId Can Not be Null or Empty.");
        RuleFor(property => property.UserRoleName).NotEmpty().WithMessage("UserRoleName Can Not be Null or Empty.");
        RuleFor(property => property.UserRoleDescription).NotEmpty().WithMessage("UserRoleDescription Can Not be Null or Empty.");
    }
}