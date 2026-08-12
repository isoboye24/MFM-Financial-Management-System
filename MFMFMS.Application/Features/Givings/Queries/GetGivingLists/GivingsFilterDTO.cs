namespace MFMFMS.Application.Features.Givings.Queries.GetGivingLists
{
    public class GivingsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string? Summary { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? MeetingId { get; set; }
    }
}
