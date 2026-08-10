using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberLists
{
    public class GetMemberListQuery : MembersFilterDTO, IRequest<PaginatedDTO<MemberListsDTO>>
    {
    }
}
