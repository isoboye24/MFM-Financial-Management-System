namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF
{
    public class FinancialSummaryMonthlyReportPDFDTO
    {
        public Guid Id { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal OpeningBalance { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenditure { get; set; }
        public decimal ClosingBalance { get; set; }

        public List<FinancialSummaryMonthlyReportServiceDTO> Services { get; set; } = new();

        public List<FinancialSummaryMonthlyReportExpenditureDTO> Expenditures { get; set; } = new();
    }
}
