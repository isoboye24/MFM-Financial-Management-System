namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists
{
    public class ExpendituresFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Summary { get; set; }
    }
}
