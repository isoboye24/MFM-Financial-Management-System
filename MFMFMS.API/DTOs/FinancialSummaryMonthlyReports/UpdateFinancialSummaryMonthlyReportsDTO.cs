namespace MFMFMS.API.DTOs.FinancialSummaryMonthlyReports
{
    public class UpdateFinancialSummaryMonthlyReportsDTO
    {
        public required int Year { get; set; }
        public required int Month { get; set; }
        public required decimal OpeningBalance { get; set; }        
    }
}
