namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists
{
    public class FinancialSummaryMonthlyReportFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public int Year { get; set; }
        public int Month { get; set; }
    }
}
