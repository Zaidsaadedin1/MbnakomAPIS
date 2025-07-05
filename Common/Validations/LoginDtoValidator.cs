using MbnakomAPIS.Common.Dtos.AuthDtos;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MbnakomAPIS.Common.Validations
{
    public class LoginDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.LoginIdentifier)
                .NotEmpty().WithMessage("Login identifier is required.")
                .Must(value => IsValidEmail(value) || IsValidPhone(value))
                .WithMessage("Login identifier must be a valid email or phone number.");



            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
        private bool IsValidEmail(string email) =>
            new EmailAddressAttribute().IsValid(email);

        private bool IsValidPhone(string phone) =>
            System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+?\d{7,15}$"); // simple phone pattern
    }

}
