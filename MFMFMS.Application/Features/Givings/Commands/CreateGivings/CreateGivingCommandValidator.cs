using FluentValidation;

namespace MFMFMS.Application.Features.Givings.Commands.CreateGivings
{
    public class CreateGivingCommandValidator : AbstractValidator<CreateGivingCommand>
    {
        public CreateGivingCommandValidator()
        {
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("The field {PropertyName} must be greater than zero.");
            RuleFor(p => p.Date).GreaterThan(DateTime.MinValue).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Summary).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.MeetingId).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
