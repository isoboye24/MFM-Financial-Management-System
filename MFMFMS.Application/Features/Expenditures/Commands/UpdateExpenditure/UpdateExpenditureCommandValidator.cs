using FluentValidation;

namespace MFMFMS.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommandValidator : AbstractValidator<UpdateExpenditureCommand>
    {
        public UpdateExpenditureCommandValidator()
        {
            RuleFor(x => x.Summary).NotEmpty().WithMessage("Summary is required.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
        }
    }
}
