namespace MFMFMS.API.DTOs.Meetings
{
    public class CreateMeetingDTO
    {
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
