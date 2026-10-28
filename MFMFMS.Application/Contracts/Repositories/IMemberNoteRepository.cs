using MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists;
using MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IMemberNoteRepository : IRepository<MemberNote>
    {
        Task<bool> Exists(string noteTitle, Guid memberId, bool isDeleted = false);
        Task<IEnumerable<MemberNote>> GetFiltered(MemberNotesFilterDTO filter);
        Task<IEnumerable<MemberNote>> GetDeletedFiltered(DeletedMemberNotesFilterDTO filter);
    }
}
