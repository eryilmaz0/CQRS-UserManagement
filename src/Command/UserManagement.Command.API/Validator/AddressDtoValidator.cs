using FluentValidation;
using UserManagement.Command.Application.Dto;

namespace UserManagement.Command.API.Validator;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(property => property.City).NotEmpty().WithMessage("City Can Not be Null or Empty.");
        RuleFor(property => property.Country).NotEmpty().WithMessage("City Can Not be Null or Empty.");
        RuleFor(property => property.FullAddress).NotEmpty().WithMessage("City Can Not be Null or Empty.");
    }
}