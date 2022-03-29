using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(property => property.Name).NotEmpty().WithMessage("Name Can Not be Null or Empty.");
        RuleFor(property => property.LastName).NotEmpty().WithMessage("LastName Can Not be Null or Empty.");
        RuleFor(property => property.Age).NotEmpty().WithMessage("Age Can Not be Null or Empty.");
        RuleFor(property => property.Gender).NotEmpty().WithMessage("Gender Can Not be Null or Empty.");
        RuleFor(property => property.UserId).NotEmpty().WithMessage("UserId Can Not be Null or Empty.");
    }
}