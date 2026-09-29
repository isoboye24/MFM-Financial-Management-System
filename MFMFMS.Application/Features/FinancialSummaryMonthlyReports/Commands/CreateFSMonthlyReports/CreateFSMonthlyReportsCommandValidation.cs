using FluentValidation;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports
{
    public class CreateFSMonthlyReportsCommandValidation : AbstractValidator<CreateFSMonthlyReportsCommand>
    {
        public CreateFSMonthlyReportsCommandValidation() 
        {
            RuleFor(p => p.Month).GreaterThan(0).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Year).GreaterThan(0).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.OpeningBalance).GreaterThan(0).WithMessage("The field {PropertyName} must be greater than zero.");
        }
    }
}
