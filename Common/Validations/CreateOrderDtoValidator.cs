using MbnakomAPIS.Common.Dtos.AppointmentDtos;
using MbnakomAPIS.Common.Dtos.OrderDtos;
using FluentValidation;

namespace MbnakomAPIS.Infrastructure.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateAppointmentDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
           
            RuleFor(x => x.ServiceType).NotEmpty().WithMessage("Service Type is required.");
           
            RuleFor(x => x.TermsAccepted).Equal(true).WithMessage("You must accept the terms.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        }
    }
}
