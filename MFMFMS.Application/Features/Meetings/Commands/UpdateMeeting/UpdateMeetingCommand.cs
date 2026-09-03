using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.UpdateMeeting
{
    public class UpdateMeetingCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string MessageTitle { get; set; }
        public required DateTime Date { get; set; }
        public string? Summary { get; set; }
        public required string Minister { get; set; }
        public required int NoOfMaleAttendance { get; set; }
        public required int NoOfFemaleAttendance { get; set; }
        public required int NoOfChildrenAttendance { get; set; }
        public required Guid MeetingCategoryId { get; set; }
    }
}
