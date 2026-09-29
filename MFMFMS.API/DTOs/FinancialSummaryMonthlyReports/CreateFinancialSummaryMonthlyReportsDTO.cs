namespace MFMFMS.API.DTOs.FinancialSummaryMonthlyReports
{
    public class CreateFinancialSummaryMonthlyReportsDTO
    {
        public required int Year { get; set; }
        public required int Month { get; set; }
        public required decimal OpeningBalance { get; set; }        
    }
}
