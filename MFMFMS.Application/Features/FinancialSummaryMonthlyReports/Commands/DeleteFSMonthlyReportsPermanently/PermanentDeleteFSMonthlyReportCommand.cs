using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.DeleteFSMonthlyReportsPermanently
{
    public class PermanentDeleteFSMonthlyReportCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
