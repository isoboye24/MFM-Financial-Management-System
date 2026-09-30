namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportDetail
{
    public class FinancialSummaryMonthlyReportDetailDTO
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public decimal OpeningBalance { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenditure { get; set; }
        public decimal ClosingBalance { get; set; }
    }
}
