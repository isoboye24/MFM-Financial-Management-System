using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists
{
    public class GetMeetingListsQuery : MeetingsFilterDTO, IRequest<PaginatedDTO<MeetingListsDTO>>
    {
    }
}
