using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists;
using MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        private readonly MFMFMSDBContext _db;
        public MeetingRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string minister, DateTime date, Guid meetingCategoryId)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            var exists = await _db.Meetings.Where(x => x.Minister == minister && x.Date >= startOfDay && x.Date < endOfDay && x.MeetingCategoryId == meetingCategoryId).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Meeting>> GetDeletedFiltered(DeletedMeetingsFilterDTO filter)
        {
            var query = _db.Meetings.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.MessageTitle))
            {
                query = query.Where(p => p.MessageTitle.Contains(filter.MessageTitle));
            }

            return await query
                .Include(x => x.MeetingCategory)
                .OrderBy(x => x.MessageTitle)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> GetFiltered(MeetingsFilterDTO filter)
        {
            var query = _db.Meetings.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.MessageTitle))
            {
                query = query.Where(p => p.MessageTitle.Contains(filter.MessageTitle));
            }

            return await query
                .Include(x => x.MeetingCategory)
                .OrderBy(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
