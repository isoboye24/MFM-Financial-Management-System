namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear
{
    public class MeetingListsByMonthAndYearDTO
    {
        public Guid Id { get; set; }
        public string MessageTitle { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Summary { get; set; }
        public string Minister { get; set; } = null!;
        public int NoOfMaleAttendance { get; set; }
        public int NoOfFemaleAttendance { get; set; }
        public int NoOfChildrenAttendance { get; set; }
        public Guid MeetingCategoryId { get; set; }
        public required string MeetingCategory { get; set; }
    }
}
