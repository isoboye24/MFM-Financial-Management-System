namespace MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists
{
    public class DeletedGivingListsDTO
    {        
        public Guid Id { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
        public required string Summary { get; set; }
        public required string MessageTitle { get; set; }
        public required string CategoryName { get; set; }
    }
}
