using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports
{
    public class CreateFSMonthlyReportsCommand : IRequest<Guid>
    {
        public required int Year { get; set; }
        public required int Month { get; set; }
        public required decimal OpeningBalance { get; set; }        
    }
}
