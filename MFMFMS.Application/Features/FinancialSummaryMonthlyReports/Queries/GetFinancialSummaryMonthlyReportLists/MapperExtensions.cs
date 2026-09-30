using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists
{
    public static class MapperExtensions
    {
        internal static FinancialSummaryMonthlyReportListsDTO ToDTO(this FinancialSummaryMonthlyReport monthlyReport)
        {
            return new FinancialSummaryMonthlyReportListsDTO
            {
                Id = monthlyReport.Id,
                Month = monthlyReport.Month,
                Year = monthlyReport.Year,
                OpeningBalance = monthlyReport.OpeningBalance,
                TotalIncome = monthlyReport.TotalIncome,
                TotalExpenditure = monthlyReport.TotalExpenditure,
                ClosingBalance = monthlyReport.ClosingBalance               
            };
        }
    }
}
