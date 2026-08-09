namespace MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists
{
    public class DeletedExpenditureListDTO
    {
        public required Guid Id { get; set; }
        public required string Summary { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
    }
}
