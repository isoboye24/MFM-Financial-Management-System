using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists
{
    public class GetDeletedMemberNoteListsQuery : DeletedMemberNotesFilterDTO, IRequest<PaginatedDTO<DeletedMemberNoteListsDTO>>
    {
    }
}
