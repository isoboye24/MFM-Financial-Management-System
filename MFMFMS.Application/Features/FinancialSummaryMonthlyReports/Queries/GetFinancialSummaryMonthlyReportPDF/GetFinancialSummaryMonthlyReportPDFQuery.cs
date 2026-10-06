using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF
{
    public class GetFinancialSummaryMonthlyReportPDFQuery : IRequest<FinancialSummaryMonthlyReportPDFDTO>
    {
        public required Guid Id { get; set; }
    }
}
