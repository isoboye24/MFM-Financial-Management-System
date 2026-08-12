namespace MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists
{
    public class DeletedGivingsFilterDTO
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
