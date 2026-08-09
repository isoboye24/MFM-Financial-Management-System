namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists
{
    public class MeetingsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? MessageTitle { get; set; }
    }
}
