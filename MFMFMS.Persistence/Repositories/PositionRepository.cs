using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists;
using MFMFMS.Application.Features.Positions.Queries.GetPositionLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly MFMFMSDBContext _db;
        public PositionRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Position>> GetDeletedFiltered(DeletedPositionsFilterDTO filter)
        {
            var query = _db.Positions.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetFiltered(PositionFilterDTO filter)
        {
            var query = _db.Positions.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

    }
}
