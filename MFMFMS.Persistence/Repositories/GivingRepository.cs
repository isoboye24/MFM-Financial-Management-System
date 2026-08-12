using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class GivingRepository : Repository<Giving>, IGivingRepository
    {
        private readonly MFMFMSDBContext _db;
        public GivingRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(Guid meetingId, Guid categoryId)
        {
            var exists = await _db.Givings.Where(x => x.MeetingId == meetingId && x.CategoryId == categoryId).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Giving>> GetDeletedFiltered(DeletedGivingsFilterDTO filter)
        {
            var query = _db.Givings.Where(x => x.IsDeleted).AsQueryable();

            if (filter.MeetingId.HasValue)
            {
                query = query.Where(p => p.MeetingId == filter.MeetingId.Value);
            }
            
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }
            
            return await query
                .Include(x => x.Category)
                .Include(x => x.Meeting)
                .OrderBy(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Giving>> GetFiltered(GivingsFilterDTO filter)
        {
            var query = _db.Givings.Where(x => !x.IsDeleted).AsQueryable();

            if (filter.MeetingId.HasValue)
            {
                query = query.Where(p => p.MeetingId == filter.MeetingId.Value);
            }

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }

            return await query
                .Include(x => x.Category)
                .Include(x => x.Meeting)
                .OrderBy(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Giving?> GetMemberDetail(Guid id)
        {
            return await _db.Givings
                           .Include(x => x.Meeting)
                           .Include(x => x.Category)
                           .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
