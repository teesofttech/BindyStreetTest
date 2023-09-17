using BindyStreet.Application.DTOs.User.UserRequest;
using FluentValidation;

namespace BindyStreet.Application.Validator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Invalid Email Address supplied");

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("Address cannot be null");

            RuleFor(x => x.Company)
                .NotNull()
                .WithMessage("Company cannot be null");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone Number is Mandatory");

            RuleFor(x => x.Website)
                .NotEmpty()
                .WithMessage("Website is Mandatory");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is Mandatory");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is Mandatory");

        }
    }
}
