using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear
{
    public class GetMeetingListsByMonthAndYearDTOQuery : MeetingListsByMonthAndYearFilterDTO, IRequest<PaginatedDTO<MeetingListsByMonthAndYearDTO>>
    {
    }
}
