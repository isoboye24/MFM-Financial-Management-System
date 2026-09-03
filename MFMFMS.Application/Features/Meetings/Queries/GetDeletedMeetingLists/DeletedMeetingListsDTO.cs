namespace MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists
{
    public class DeletedMeetingListsDTO
    {
        public required Guid Id { get; set; }
        public required string MessageTitle { get; set; }
        public required DateTime Date { get; set; }
        public string? Summary { get; set; }
        public required string Minister { get; set; }
        public required int NoOfMaleAttendance { get; set; }
        public required int NoOfFemaleAttendance { get; set; }
        public required int NoOfChildrenAttendance { get; set; }
        public required string MeetingCategory { get; set; }
    }
}
