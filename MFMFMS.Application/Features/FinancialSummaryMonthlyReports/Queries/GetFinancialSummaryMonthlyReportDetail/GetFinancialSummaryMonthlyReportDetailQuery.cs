using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportDetail
{
    public class GetFinancialSummaryMonthlyReportDetailQuery : IRequest<FinancialSummaryMonthlyReportDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
