namespace MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists
{
    public class DeletedExpendituresFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Summary { get; set; }
    }
}
