using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteByMemberIdLists
{
    public class GetMemberNoteByMemberIdListsQuery : MemberNoteByMemberIdFilterDTO, IRequest<PaginatedDTO<MemberNoteByMemberIdListsDTO>>
    {
    }
}
