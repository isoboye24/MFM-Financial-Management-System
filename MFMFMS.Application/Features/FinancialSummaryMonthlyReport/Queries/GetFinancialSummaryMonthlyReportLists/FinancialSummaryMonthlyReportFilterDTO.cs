namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReport.Queries.GetFinancialSummaryMonthlyReportLists
{
    public class FinancialSummaryMonthlyReportFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public int Year { get; private set; }
        public int Month { get; private set; }

        public decimal OpeningBalance { get; private set; }
        public decimal TotalIncome { get; private set; }
        public decimal TotalExpenditure { get; private set; }
        public decimal ClosingBalance { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
