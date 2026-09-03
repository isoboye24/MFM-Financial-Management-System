namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists
{
    public class MeetingListsDTO
    {
        public Guid Id { get; set; }
        public required string MessageTitle { get; set; }
        public DateTime Date { get; set; }
        public string? Summary { get; set; }
        public required string Minister { get; set; }
        public int NoOfMaleAttendance { get; set; }
        public int NoOfFemaleAttendance { get; set; }
        public int NoOfChildrenAttendance { get; set; }
        public required string MeetingCategory { get; set; }
    }
}
