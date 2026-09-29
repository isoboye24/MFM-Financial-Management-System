using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReport.Queries.GetFinancialSummaryMonthlyReportLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class FinancialSummaryMonthlyReportRepository : Repository<FinancialSummaryMonthlyReport>, IFinancialSummaryMonthlyReportRepository
    {
        private readonly MFMFMSDBContext _db;
        public FinancialSummaryMonthlyReportRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }


        public async Task<bool> Exists(int year, int month, bool isDeleted = false)
        {
            var exists = await _db.FinancialSummaryMonthlyReports.Where(x => x.Year == year && x.Month == month && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<FinancialSummaryMonthlyReport>> GetFiltered(FinancialSummaryMonthlyReportFilterDTO filter)
        {
            var query = _db.FinancialSummaryMonthlyReports.Where(x => !x.IsDeleted).AsQueryable();

            return await query
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Month)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
