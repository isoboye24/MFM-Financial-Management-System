using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.CreateMeetings
{
    public class CreateMeetingsCommand : IRequest<Guid>
    {
        public required string MessageTitle { get; set; }
        public required DateTime Date { get; set; }
        public string? Summary { get; set; }
        public required string Minister { get; set; }
        public required int NoOfMaleAttendance { get; set; }
        public required int NoOfFemaleAttendance { get; set; }
        public required int NoOfChildrenAttendance { get; set; }
    }
}
