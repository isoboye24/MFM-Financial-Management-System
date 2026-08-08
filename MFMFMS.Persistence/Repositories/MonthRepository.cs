using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Months.GetMonthsList;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class MonthRepository : IMonthRepository
    {
        private readonly MFMFMSDBContext _db;

        public MonthRepository(MFMFMSDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Month>> GetFiltered(
            MonthsFilterDTO filter)
        {
            var query = _db.Months.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x =>
                    x.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Month?> GetById(int id)
        {
            return await _db.Months
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await _db.Months.CountAsync();
        }
    }
}

