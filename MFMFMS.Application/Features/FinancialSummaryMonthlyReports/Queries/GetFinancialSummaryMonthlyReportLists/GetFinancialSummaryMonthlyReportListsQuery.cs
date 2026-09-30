using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists
{
    public class GetFinancialSummaryMonthlyReportListsQuery : FinancialSummaryMonthlyReportFilterDTO, IRequest<PaginatedDTO<FinancialSummaryMonthlyReportListsDTO>>
    {
    }
}
