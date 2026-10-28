using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists;
using MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class MemberNoteRepository : Repository<MemberNote>, IMemberNoteRepository
    {
        private readonly MFMFMSDBContext _db;

        public MemberNoteRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string noteTitle, Guid memberId, bool isDeleted = false)
        {
            var exists = await _db.MemberNotes.Where(x => x.NoteTitle == noteTitle && x.MemberId == memberId && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<MemberNote>> GetDeletedFiltered(DeletedMemberNotesFilterDTO filter)
        {
            var query = _db.MemberNotes.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.NoteTitle))
            {
                query = query.Where(p => p.NoteTitle.Contains(filter.NoteTitle));
            }

            return await query
                .Include(x => x.Member)
                .OrderByDescending(x => x.CreationTime)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberNote>> GetFiltered(MemberNotesFilterDTO filter)
        {
            var query = _db.MemberNotes.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.NoteTitle))
            {
                query = query.Where(p => p.NoteTitle.Contains(filter.NoteTitle));
            }

            return await query
                .Include(x => x.Member)
                .OrderByDescending(x => x.CreationTime)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
