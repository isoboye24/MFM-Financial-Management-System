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

        public async Task<IEnumerable<Meeting>> GetDeletedFiltered(DeletedMeetingsFilterDTO filter)
        {
            var query = _db.Meetings.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.MessageTitle))
            {
                query = query.Where(p => p.MessageTitle.Contains(filter.MessageTitle));
            }

            return await query
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
                .OrderBy(x => x.MessageTitle)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
