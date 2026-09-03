using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists;
using MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class MeetingCategoryRepository : Repository<MeetingCategory>, IMeetingCategoryRepository
    {
        private readonly MFMFMSDBContext _db;
        public MeetingCategoryRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name)
        {
            var exists = await _db.MeetingCategories.Where(x => x.Name == name).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<MeetingCategory>> GetDeletedFiltered(DeletedMeetingCategoriesFilterDTO filter)
        {
            var query = _db.MeetingCategories.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetingCategory>> GetFiltered(MeetingCategoriesFilterDTO filter)
        {
            var query = _db.MeetingCategories.Where(x => !x.IsDeleted);

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
