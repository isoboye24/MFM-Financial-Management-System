using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingDetail
{
    public class GetMeetingDetailQuery : IRequest<MeetingDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
