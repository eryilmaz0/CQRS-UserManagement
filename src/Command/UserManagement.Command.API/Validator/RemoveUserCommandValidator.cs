using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
{
    public RemoveUserCommandValidator()
    {
        RuleFor(property => property.UserId).NotEmpty().WithMessage("UserId Can Not be Null or Empty.");
    }
}