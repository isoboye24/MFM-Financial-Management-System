using FluentValidation;

namespace MFMFMS.Application.Features.Givings.Commands.UpdateGiving
{
    public class UpdateGivingCommandValidator : AbstractValidator<UpdateGivingCommand>
    {
        public UpdateGivingCommandValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(p => p.Summary).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.MeetingId).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
