using MbnakomAPIS.Common.Dtos.AuthDtos;
using FluentValidation;

namespace MbnakomAPIS.Common.Validations
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password should be at least 6 characters.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        }
    }

}
