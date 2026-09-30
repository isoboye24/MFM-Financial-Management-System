using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.UpdateFSMonthlyReports
{
    public class UpdateFSMonthlyReportsCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required int Year { get; set; }
        public required int Month { get; set; }
        public required decimal OpeningBalance { get; set; }
    }
}
