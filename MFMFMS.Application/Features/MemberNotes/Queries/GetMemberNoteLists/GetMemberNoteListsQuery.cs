using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists
{
    public class GetMemberNoteListsQuery : MemberNotesFilterDTO, IRequest<PaginatedDTO<MemberNoteListsDTO>>
    {
    }
}
