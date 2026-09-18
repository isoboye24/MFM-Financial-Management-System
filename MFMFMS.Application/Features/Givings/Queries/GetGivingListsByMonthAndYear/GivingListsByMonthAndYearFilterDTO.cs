namespace MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear
{
    public class GivingListsByMonthAndYearFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }

        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public Guid MeetingCategoryId { get; set; }
        public Guid MeetingId { get; set; }

        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
