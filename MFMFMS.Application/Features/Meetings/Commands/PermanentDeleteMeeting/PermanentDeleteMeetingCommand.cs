using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.PermanentDeleteMeeting
{
    public class PermanentDeleteMeetingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
