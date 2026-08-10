using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.DeleteMeeting
{
    public class DeleteMeetingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
