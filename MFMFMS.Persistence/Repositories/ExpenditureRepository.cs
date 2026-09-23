using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Expenditures.Queries.GetAnnualExpenditureStatistics;
using MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear;
using MFMFMS.Application.Features.Expenditures.Queries.GetMonthlyExpendituresStatistics;
using MFMFMS.Application.Features.Expenditures.Queries.GetTotalExpenditureStatistics;
using MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class ExpenditureRepository : Repository<Expenditure>, IExpenditureRepository
    {
        private readonly MFMFMSDBContext _db;

        public ExpenditureRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string summary, DateTime date, bool isDeleted = false)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            var exists = await _db.Expenditures.Where(x => x.Summary == summary && x.Date >= startOfDay && x.Date < endOfDay && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Expenditure>> GetDeletedFiltered(DeletedExpendituresFilterDTO filter)
        {
            var query = _db.Expenditures.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Summary))
            {
                query = query.Where(p => p.Summary.Contains(filter.Summary));
            }

            return await query
                .OrderBy(x => x.Summary)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expenditure>> GetFiltered(ExpendituresFilterDTO filter)
        {
            var query = _db.Expenditures.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Summary))
            {
                query = query.Where(p => p.Summary.Contains(filter.Summary));
            }

            return await query
                .OrderBy(x => x.Summary)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expenditure>> GetFilteredByMonthAndYear(ExpenditureListsByMonthAndYearFilterDTO filter)
        {
            var query = _db.Expenditures.Where(x => !x.IsDeleted).AsQueryable();

            if (filter.Month.HasValue)
            {
                query = query.Where(x =>
                    x.Date.Month == filter.Month.Value);
            }

            if (filter.Year.HasValue)
            {
                query = query.Where(x =>
                    x.Date.Year == filter.Year.Value);
            }

            return await query                
                .OrderByDescending(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<MonthlyExpendituresStatisticsDTO> GetMonthlyExpenditureStatistics(int month, int year)
        {
            var amount = await _db.Expenditures
                                    .Where(x => !x.IsDeleted && x.Date.Month == month && x.Date.Year == year)
                                    .SumAsync(x => x.Amount);

            return amount == 0 ? new MonthlyExpendituresStatisticsDTO { MonthlyExpenditures = 0 } : new MonthlyExpendituresStatisticsDTO { MonthlyExpenditures = amount };
        }

        public async Task<AnnualExpendituresStatisticsDTO> GetAnnualExpenditureStatistics(int year)
        {
            var amount = await _db.Expenditures
                                    .Where(x => !x.IsDeleted && x.Date.Year == year)
                                    .SumAsync(x => x.Amount);

            return amount == 0 ? new AnnualExpendituresStatisticsDTO { AnnualExpenditures = 0 } : new AnnualExpendituresStatisticsDTO { AnnualExpenditures = amount };
        }

        public async Task<TotalExpendituresStatisticsDTO> GetTotalExpenditureStatistics()
        {
            var amount = await _db.Expenditures
                                    .Where(x => !x.IsDeleted)
                                    .SumAsync(x => x.Amount);

            return amount == 0 ? new TotalExpendituresStatisticsDTO { TotalExpenditures = 0 } : new TotalExpendituresStatisticsDTO { TotalExpenditures = amount };
        }
    }
}
