using MFMFMS.Application.Contracts.PDF;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF;
using QuestPDF.Fluent;

namespace MFMFMS.Infrastructure.PDF;

public sealed class MonthlyServiceReportPdfGenerator : IMonthlyServiceReportPdfGenerator
{
    public byte[] Generate(FinancialSummaryMonthlyReportPDFDTO report)
    {
        ArgumentNullException.ThrowIfNull(report);

        var document = new MonthlyServiceReportDocument(report);

        return document.GeneratePdf();
    }
}
