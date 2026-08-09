namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureDetail
{
    public class ExpenditureDetailDTO
    {
        public Guid Id { get; set; }
        public required string Summary { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
    }
}
