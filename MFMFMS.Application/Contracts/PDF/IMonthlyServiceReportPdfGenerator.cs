using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF;

namespace MFMFMS.Application.Contracts.PDF
{
    public interface IMonthlyServiceReportPdfGenerator
    {
        byte[] Generate(FinancialSummaryMonthlyReportPDFDTO report);
    }
}
