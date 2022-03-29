using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(property => property.Name).NotEmpty().WithMessage("Name Can Not be Null or Empty.");
        RuleFor(property => property.LastName).NotEmpty().WithMessage("LastName Can Not be Null or Empty.");
        RuleFor(property => property.Age).NotEmpty().WithMessage("Age Can Not be Null or Empty.");
        RuleFor(property => property.Email).NotEmpty().WithMessage("Email Can Not be Null or Empty.");
        RuleFor(property => property.Password).NotEmpty().WithMessage("Password Can Not be Null or Empty.");
        RuleFor(property => property.Gender).IsInEnum().WithMessage("Gender Can Not be Null or Empty.");
        RuleFor(property => property.Address).NotNull().WithMessage("Address Can Not be Null.").SetValidator(new AddressDtoValidator());
    }
}