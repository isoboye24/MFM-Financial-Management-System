namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear
{
    public class MeetingListsByMonthAndYearFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
