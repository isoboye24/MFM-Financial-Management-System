using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
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

        public async Task<bool> Exists(string summary, DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            var exists = await _db.Expenditures.Where(x => x.Summary == summary && x.Date >= startOfDay && x.Date < endOfDay).AnyAsync();

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
    }
}
