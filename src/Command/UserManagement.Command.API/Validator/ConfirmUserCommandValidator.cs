using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class ConfirmUserCommandValidator : AbstractValidator<ConfirmUserCommand>
{
    public ConfirmUserCommandValidator()
    {
        RuleFor(property => property.UserId).NotEmpty().WithMessage("UserId Can Not be Null or Empty.");
        RuleFor(property => property.EmailConfirmationToken).NotEmpty().WithMessage("EmailConfirmationToken Can Not be Null or Empty.");
    }
}