using FluentValidation;

namespace MFMFMS.Application.Features.Expenditures.Commands.CreateExpenditures
{
    public class CreateExpenditureCommandValidator : AbstractValidator<CreateExpenditureCommand>
    {
        public CreateExpenditureCommandValidator()
        {
            RuleFor(p => p.Summary).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("The field {PropertyName} must be greater than zero.");
            RuleFor(p => p.Date).GreaterThan(DateTime.MinValue).WithMessage("The field {PropertyName} is required.");
        }
    }
}
