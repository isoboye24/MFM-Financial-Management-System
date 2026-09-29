using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IFinancialSummaryMonthlyReportRepository : IRepository<FinancialSummaryMonthlyReport>
    {
        Task<bool> Exists(int year, int month, bool isDeleted = false);
        Task<IEnumerable<FinancialSummaryMonthlyReport>> GetFiltered(FinancialSummaryMonthlyReportFilterDTO filter);
    }
}
