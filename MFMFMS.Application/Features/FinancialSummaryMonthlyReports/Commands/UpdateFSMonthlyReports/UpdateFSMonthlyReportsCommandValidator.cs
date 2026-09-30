using FluentValidation;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.UpdateFSMonthlyReports
{
    public class UpdateFSMonthlyReportsCommandValidator : AbstractValidator<UpdateFSMonthlyReportsCommand>
    {
        public UpdateFSMonthlyReportsCommandValidator() 
        {
            RuleFor(p => p.Month).GreaterThan(0).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Year).GreaterThan(0).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.OpeningBalance).GreaterThan(0).WithMessage("The field {PropertyName} must be greater than zero.");
        }
    }
}
