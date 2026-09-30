using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportDetail
{
    public static class MapperExtensions
    {
        internal static FinancialSummaryMonthlyReportDetailDTO ToDTO(this FinancialSummaryMonthlyReport monthlyReport)
        {
            return new FinancialSummaryMonthlyReportDetailDTO
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
