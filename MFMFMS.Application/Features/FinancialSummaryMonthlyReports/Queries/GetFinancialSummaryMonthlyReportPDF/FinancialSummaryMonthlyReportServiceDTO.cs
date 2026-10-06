namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF
{
    public class FinancialSummaryMonthlyReportServiceDTO
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Minister { get; set; } = string.Empty;

        public int Male { get; set; }
        public int Female { get; set; }
        public int Children { get; set; }
        public int TotalAttendance { get; set; }

        public decimal Offering { get; set; }
        public decimal Tithe { get; set; }
        public decimal Seed { get; set; }
        public decimal OtherIncome { get; set; }

        public decimal TotalIncome { get; set; }
    }
}
