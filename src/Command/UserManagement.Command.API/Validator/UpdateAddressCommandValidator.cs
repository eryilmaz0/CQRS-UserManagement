using FluentValidation;
using UserManagement.Command.Application.CommandModel;

namespace UserManagement.Command.API.Validator;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(property => property.City).NotEmpty().WithMessage("City Can Not be Null or Empty.");
        RuleFor(property => property.Country).NotEmpty().WithMessage("Country Can Not be Null or Empty.");
        RuleFor(property => property.FullAddress).NotEmpty().WithMessage("FullAddress Can Not be Null or Empty.");
        RuleFor(property => property.AddressId).NotEmpty().WithMessage("AddressId Can Not be Null or Empty.");
    }
}