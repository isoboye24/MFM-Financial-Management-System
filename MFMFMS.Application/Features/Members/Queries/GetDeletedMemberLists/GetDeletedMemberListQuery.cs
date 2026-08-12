using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists
{
    public class GetDeletedMemberListQuery : DeletedMembersFilterDTO, IRequest<PaginatedDTO<DeletedMemberListDTO>>
    {
    }
}
