using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists
{
    public class GetDeletedMeetingListsQuery : DeletedMeetingsFilterDTO, IRequest<PaginatedDTO<DeletedMeetingListsDTO>>
    {
    }
}
