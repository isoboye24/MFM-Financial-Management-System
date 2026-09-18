namespace MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear
{
    public class GivingListsByMonthAndYearDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public Guid MeetingId { get; set; }
        public string Minister { get; set; } = string.Empty;
        public string MessageTitle { get; set; } = string.Empty;

        public Guid MeetingCategoryId { get; set; }
        public string MeetingCategoryName { get; set; } = string.Empty;
    }
}
