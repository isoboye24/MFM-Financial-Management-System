using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.RestoreMeeting
{
    public class RestoreMeetingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
